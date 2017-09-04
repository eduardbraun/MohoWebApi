using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using ApiMoho.Commands.Interfaces;
using ApiMoho.Models;
using ApiMoho.Models.Dtos;
using ApiMoho.Models.Request;
using ApiMoho.Repositories.interfaces;
using ApiMoho.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiMoho.Controllers
{
    [Produces("application/json")]
    [Route("api/Listing")]
    public class ListingController : Controller
    {
        private ILogger<ListingController> _logger;
        private IListingCommand _listingCommand;
        private readonly UserManager<UserModel> _userManager;

        public ListingController(ILogger<ListingController> logger, IListingCommand listingCommand,
            UserManager<UserModel> userManager)
        {
            _logger = logger;
            _listingCommand = listingCommand;
            _userManager = userManager;
        }

        [Authorize]
        [HttpPost("NewListing")]
        public async Task<IActionResult> NewListing([FromBody] AddListingDto addListingDto)
        {
            try
            {
                var id = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var user = await _userManager.FindByEmailAsync(id);

                var listing =
                    await _listingCommand.AddListingCommand(addListingDto, user.FirstName + user.LastName, user.Id);
                return Ok(listing);
            }
            catch (Exception ex)
            {
                _logger.LogError($"error while creating listing: {ex}");
                return StatusCode((int) HttpStatusCode.InternalServerError, "error while creating listing");
            }
        }

        [AllowAnonymous]
        [HttpGet("GetAllListing")]
        public async Task<IActionResult> GetAllListings()
        {
            try
            {
                var allListings = await _listingCommand.GetAllListingsCommand();

                return Ok(allListings);
            }
            catch (Exception ex)
            {
                _logger.LogError($"error while creating listing: {ex}");
                return StatusCode((int) HttpStatusCode.InternalServerError, "error while creating listing");
            }
        }

       

        [AllowAnonymous]
        [HttpGet("GetAllListingForUser/{userid}", Name = "GetAllListingForUser")]
        public async Task<IActionResult> GetAllListingsForSpecificUser(string userid)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userid);

                if (user != null)
                {
                    var allListings = await _listingCommand.GetAllListingsForUserCommand(userid);

                    return Ok(allListings);
                }
                else
                {
                    _logger.LogError($"error user does not exis");
                    return StatusCode((int) HttpStatusCode.InternalServerError, "error user does not exist");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"error while getting all lists for user: {ex}");
                return StatusCode((int) HttpStatusCode.InternalServerError, "error while getting alllists for user");
            }
        }

        [Authorize]
        [HttpPost("UpdateListing")]
        public async Task<IActionResult> UpdateListing([FromBody] UpdateListingRequest updateListingRequest)
        {
            try
            {
                var id = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var user = await _userManager.FindByEmailAsync(id);

                if (user != null)
                {
                    if (user.Id != updateListingRequest.OwnerId)
                    {
                        return StatusCode((int) HttpStatusCode.InternalServerError,
                            "you are not the owner of that listing");
                    }
                    var allListings = await _listingCommand.UpdateListing(updateListingRequest, user.Id);

                    return Ok(allListings);
                }
                else
                {
                    _logger.LogError($"error user does not exis");
                    return StatusCode((int) HttpStatusCode.InternalServerError, "error user does not exist");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"error while getting all lists for user: {ex}");
                return StatusCode((int) HttpStatusCode.InternalServerError, "error while getting alllists for user");
            }
        }

        [AllowAnonymous]
        [HttpGet("GetFilterOptions")]
        public async Task<IActionResult> GetFilterOptions()
        {
            try
            {
                var filterList = await _listingCommand.GetFilterList();

                return Ok(filterList);
            }
            catch (Exception ex)
            {
                _logger.LogError($"error while getting filter list {ex}");
                return StatusCode((int)HttpStatusCode.InternalServerError, "error while getting filter list");
            }
        }

        [Authorize]
        [HttpPost("DeleteListing")]
        public async Task<IActionResult> DeleteListing([FromBody] DeleteListingRequest deleteListingRequest)
        {
            try
            {
                var id = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var user = await _userManager.FindByEmailAsync(id);

                if (user != null)
                {
                    if (user.Id != deleteListingRequest.OwnerId)
                    {
                        return StatusCode((int)HttpStatusCode.InternalServerError,
                            "you are not the owner of that listing");
                    }
                    await _listingCommand.DeleteListing(deleteListingRequest, user.Id);

                    return Ok("Successfully Removed Listing");
                }
                else
                {
                    _logger.LogError($"error user does not exis");
                    return StatusCode((int)HttpStatusCode.InternalServerError, "error user does not exist");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"error while getting all lists for user: {ex}");
                return StatusCode((int)HttpStatusCode.InternalServerError, "error while getting alllists for user");
            }
        }

        [Authorize]
        [HttpPost("SetListingEnabled")]
        public async Task<IActionResult> SetListingEnabled([FromBody] SetListingEnabledRequest setListingEnabledRequest)
        {
            try
            {
                var id = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var user = await _userManager.FindByEmailAsync(id);

                if (user != null)
                {
                    if (user.Id != setListingEnabledRequest.OwnerId)
                    {
                        return StatusCode((int)HttpStatusCode.InternalServerError,
                            "you are not the owner of that listing");
                    }
                    await _listingCommand.SetListingStatus(setListingEnabledRequest, user.Id);

                    return Ok("Successfully set listing status");
                }
                else
                {
                    _logger.LogError($"error user does not exis");
                    return StatusCode((int)HttpStatusCode.InternalServerError, "error user does not exist");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"error while updated the listing: {ex}");
                return StatusCode((int)HttpStatusCode.InternalServerError, "error while updating the listing");
            }
        }
    }
}