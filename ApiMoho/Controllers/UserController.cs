using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Security.Claims;
using System.Threading.Tasks;
using ApiMoho.Commands.Interfaces;
using ApiMoho.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiMoho.Controllers
{

    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private ILogger<UserController> _logger;
        private IHttpContextAccessor _httpContextAccessor;
        private IUserCommand _userCommand;
        private readonly UserManager<UserModel> _userManager;

        public UserController(IHttpContextAccessor httpContextAccessor, IUserCommand userCommand, ILogger<UserController> logger,
            UserManager<UserModel> userManager)
        {
            _userManager = userManager;
            _logger = logger;
            _userCommand = userCommand;
            _httpContextAccessor = httpContextAccessor;
        }
        [Authorize]
        [HttpGet]
        [Route("userDescription")]
        public async Task<IActionResult> GetUserDescription()
        {
            return null;
        }
        [Authorize]
        [HttpPost]
        [Route("ChangeProfile")]
        public async Task<IActionResult> ChangeProfileImage([FromForm]IFormFile file)
        {
            try
            {
                var id = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var user = await _userManager.FindByEmailAsync(id);

                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    var image = memoryStream.ToArray();

                    user.AvatarImage = image;

                    await _userManager.UpdateAsync(user);
                }


                var updatedProfile = _userCommand.GetUserProfile(user);

                return Ok(updatedProfile);

            }
            catch (Exception e)
            {
                _logger.LogError($"error while changing profile for user: {e}");
                return StatusCode((int)HttpStatusCode.InternalServerError, "error while changing profile for user");
            }
            
        }

        [Authorize]
        [HttpGet]
        [Route("GetProfile")]
        public async Task<IActionResult> GetUserProfile()
        {
            try
            {
                var id = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var user = await _userManager.FindByEmailAsync(id);

                var updatedProfile = _userCommand.GetUserProfile(user).Result;

                return Ok(updatedProfile);

            }
            catch (Exception e)
            {
                _logger.LogError($"error while getting profile for user: {e}");
                return StatusCode((int)HttpStatusCode.InternalServerError, "error while getting profile for user");
            }

        }
    }
}