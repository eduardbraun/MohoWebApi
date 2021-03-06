﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ApiMoho.Filters;
using ApiMoho.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace ApiMoho.Controllers
{
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;
        private readonly RoleManager<UserRole> _roleManager;
        private IPasswordHasher<UserModel> _passwordHasher;
        private IConfiguration _configuration;
        private ILogger<AuthController> _logger;

        public AuthController(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager,
            RoleManager<UserRole> roleManager
            , IPasswordHasher<UserModel> passwordHasher, IConfiguration configuration, ILogger<AuthController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _logger = logger;
            _passwordHasher = passwordHasher;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please fill out all fields!");
            }
            var user = new UserModel()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Username,
                Email = model.Email,
                Age = model.Age,
                Location = model.Location
            };
            try
            {
                var existsByUserName = await _userManager.FindByNameAsync(user.UserName);
                var existsByEmail = await _userManager.FindByEmailAsync(user.Email);

                if (existsByUserName != null || existsByEmail != null)
                {
                    return BadRequest("Username and Email need to be Unique");
                }

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return Ok(result);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("error", error.Description);
                }
                return BadRequest(result.Errors);
            }
            catch (Exception ex)
            {
                _logger.LogError($"error while registering: {ex}");
                return StatusCode((int)HttpStatusCode.InternalServerError, "error while registering");
            }
        }

        [ValidateForm]
        [HttpPost("CreateToken")]
        [Route("token")]
        public async Task<IActionResult> CreateToken([FromForm] LoginModel model)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    return StatusCode((int)HttpStatusCode.Unauthorized, "Username or Password is wrong. Do you have an account?");
                }
                if (_passwordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password) ==
                    PasswordVerificationResult.Success)
                {
                    var userClaims = await _userManager.GetClaimsAsync(user);

                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email) 
                    }.Union(userClaims);

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        issuer: _configuration["Tokens:Issuer"],
                        audience: _configuration["Tokens:Audience"],
                        claims: claims,
                        expires: DateTime.UtcNow.AddDays(1),
                        signingCredentials: creds);

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        firstname = user.FirstName,
                        lastname= user.LastName,
                        email = user.Email,
                        username = user.UserName,
                        userId = user.Id,
                        expiration = token.ValidTo
                    });
                }
                return StatusCode((int)HttpStatusCode.Unauthorized, "Username or Password is wrong. Do you have an account?");
            }
            catch (Exception ex)
            {
                _logger.LogError($"error while creating token: {ex}");
                return StatusCode((int) HttpStatusCode.InternalServerError, "error while creating token" + ex);
            }
        }
    }
}