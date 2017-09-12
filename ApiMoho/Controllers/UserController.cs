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
using ApiMoho.Models.Request;
using ApiMoho.Models.Request.UserRequest;
using ApiMoho.Models.Response;
using ApiMoho.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiMoho.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private ILogger<UserController> _logger;
        private IHttpContextAccessor _httpContextAccessor;
        private IUserCommand _userCommand;
        private IListingCommand _listingCommand;
        private readonly UserManager<UserModel> _userManager;

        public UserController(IHttpContextAccessor httpContextAccessor, IUserCommand userCommand,
            ILogger<UserController> logger, UserManager<UserModel> userManager, IListingCommand listingCommand)
        {
            _listingCommand = listingCommand;
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
        public async Task<IActionResult> ChangeProfileImage()
        {
            try
            {
                var id = HttpContext.User.FindFirst(ClaimTypes.Email).Value;
                var user = await _userManager.FindByEmailAsync(id);

                var files = Request.Form.Files;

                var filecount = files.Count;

                if (filecount > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        var file = files[0];
                        await file.CopyToAsync(memoryStream);
                        var image = memoryStream.ToArray();

                        user.AvatarImage = image;

                        await _userManager.UpdateAsync(user);
                    }
                    var updatedProfile = _userCommand.GetUserProfile(user).Result;
                    return Ok(updatedProfile);
                }

                return StatusCode((int)HttpStatusCode.InternalServerError, "No Image Found");
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
                var id = HttpContext.User.FindFirst(ClaimTypes.Email).Value;
                var user = await _userManager.FindByEmailAsync(id);

                var profile = _userCommand.GetUserProfile(user).Result;
                

                var response = new GetUserProfileResponse()
                {
                    UserProfileDto = profile
                };

                return Ok(response);

            }
            catch (Exception e)
            {
                _logger.LogError($"error while getting profile for user: {e}");
                return StatusCode((int)HttpStatusCode.InternalServerError, "error while getting profile for user");
            }

        }

        [Authorize]
        [HttpGet("GetProfileForUserSettings")]
        public async Task<IActionResult> GetAllListingsForUser()
        {
            try
            {
                var id = HttpContext.User.FindFirst(ClaimTypes.Email).Value;
                var user = await _userManager.FindByEmailAsync(id);

                var allListings = await _listingCommand.GetAllListingsForUserCommand(user.Id);
                var profile = await _userCommand.GetUserProfile(user);
                var reviews = await _userCommand.GetUserReviews(user.Id);

                var response = new GetProfileForUserSettingsResponse()
                {
                    UserListingCollectionDto = allListings,
                    UserProfileDto = profile,
                    UserProfileReviewList = reviews
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"error while getting profile for user: {ex}");
                return StatusCode((int)HttpStatusCode.InternalServerError, "error while getting profile for user");
            }
        }

        [Authorize]
        [HttpPost]
        [Route("GiveReviewForUser")]
        public async Task<IActionResult> GiveReviewForUser([FromBody] GiveReviewForUserRequest giveReviewForUserRequest)
        {
            try
            {
                var id = HttpContext.User.FindFirst(ClaimTypes.Email).Value;
                var user = await _userManager.FindByEmailAsync(id);

                var reviewUser = await _userManager.FindByIdAsync(giveReviewForUserRequest.OwnerId);

                if (user == null)
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, "Wrong User");
                }

                if (reviewUser == null)
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, "User does not exist");
                }

                await _userCommand.GiveUserReviewCommand(giveReviewForUserRequest, user.Id, _userManager);

                return Ok(new
                {
                    Success = true,
                    Message = "Success fully added review."
                });
            }
            catch (Exception e)
            {
                _logger.LogError($"error while changing profile for user: {e}");
                return StatusCode((int)HttpStatusCode.InternalServerError, "error while changing profile for user");
            }

        }

        [AllowAnonymous]
        [HttpGet("id={id}")]
        public async Task<IActionResult> GetUserProfileById(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return BadRequest("User does not exist");
                }

                var profile = _userCommand.GetUserProfile(user).Result;
                var listings = await _listingCommand.GetAllListingsForUserCommand(user.Id);
                var review = await _userCommand.GetUserReviews(user.Id);
                var response = new GetProfileForUserSettingsResponse()
                {
                    UserProfileDto = profile,
                    UserListingCollectionDto = listings,
                    UserProfileReviewList = review
                };

                return Ok(new
                {
                    Profile = response,
                    Success = true,
                    Message = "Successfully loaded profile"
                });

            }
            catch (Exception e)
            {
                _logger.LogError($"error while getting listing: {e}");
                return StatusCode((int)HttpStatusCode.InternalServerError, "error while getting listing");
            }
        }

        [Authorize]
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordRequest changePasswordRequest)
        {
            try
            {
                var id = HttpContext.User.FindFirst(ClaimTypes.Email).Value;
                var user = await _userManager.FindByEmailAsync(id);

                if (user == null)
                {
                    return BadRequest(error: "User does not exist!");
                }

                await _userManager.ChangePasswordAsync(user, changePasswordRequest.CurrentPassword,
                    changePasswordRequest.Password);

                var updatedUser =await _userManager.FindByEmailAsync(id);

                var updatedUserDto = await _userCommand.GetUserProfile(updatedUser);

                return Ok(new
                {
                    Message = "Successfully Change Your Password",
                    User = updatedUserDto
                });
            }
            catch (Exception e)
            {
                _logger.LogError($"error while getting listing: {e}");
                return StatusCode((int)HttpStatusCode.InternalServerError, "error while getting listing");
            }
        }

        [AllowAnonymous]
        [HttpGet("SendEmail")]
        public async Task<IActionResult> SendEmail()
        {
            try
            {
               var emailService = new EmailService();

                await emailService.SendActivationEmail();

                return Ok(new
                {
                 Message = "Email has been send"
                });
            }
            catch (Exception e)
            {
                _logger.LogError($"error while getting listing: {e}");
                return StatusCode((int)HttpStatusCode.InternalServerError, "error while getting listing");
            }
        }

    }
}