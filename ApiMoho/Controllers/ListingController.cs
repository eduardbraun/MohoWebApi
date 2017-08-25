using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using ApiMoho.Commands.Interfaces;
using ApiMoho.Models;
using ApiMoho.Models.Dtos;
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
        private IListingCommand  _listingCommand;
        private readonly UserManager<UserModel> _userManager;

        public ListingController(ILogger<ListingController> logger, IListingCommand listingCommand, UserManager<UserModel> userManager)
        {
            _logger = logger;
            _listingCommand = listingCommand;
            _userManager = userManager;
        }
        [Authorize]
        [HttpPost("NewListing")]
        [Route("token")]
        public async Task<IActionResult> NewListing([FromForm] AddListingDto addListingDto)
        {
            try
            {
                var id = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var user = await _userManager.FindByEmailAsync(id);
         
                var listing = await _listingCommand.AddListingCommand(addListingDto, user.FirstName + user.LastName, user.Id);
                return Ok(listing);
            }
            catch (Exception ex)
            {
                _logger.LogError($"error while creating listing: {ex}");
                return StatusCode((int)HttpStatusCode.InternalServerError, "error while creating listing");
            }
        }

        [AllowAnonymous]
        [HttpGet("GetAllListing")]
        [Route("token")]
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
                return StatusCode((int)HttpStatusCode.InternalServerError, "error while creating listing");
            }
        }

    }
}