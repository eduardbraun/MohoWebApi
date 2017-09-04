using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ApiMoho.Commands.Interfaces;
using ApiMoho.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiMoho.Controllers
{
    [Produces("application/json")]
    [Route("api/Browse")]
    public class BrowseController : Controller
    {
        private ILogger<ListingController> _logger;
        private IListingCommand _listingCommand;
        private IBrowseCommand _browseCommand;
        private readonly UserManager<UserModel> _userManager;

        public BrowseController(ILogger<ListingController> logger, IListingCommand listingCommand,
            UserManager<UserModel> userManager, IBrowseCommand browserCommand)
        {
            _browseCommand = browserCommand;
            _logger = logger;
            _listingCommand = listingCommand;
            _userManager = userManager;
        }

        [AllowAnonymous]
        [HttpGet("id={id}")]
        public async Task<IActionResult> GetListingView(int id)
        {
            try
            {
                var listing = await _browseCommand.ViewListing(id, _userManager);

                if (listing != null)
                {
                    return Ok(listing);
                }
                _logger.LogError($"error listing does not exis");
                return StatusCode((int)HttpStatusCode.InternalServerError, "error listing does not exist");
            }
            catch (Exception e)
            {
                _logger.LogError($"error while getting listing: {e}");
                return StatusCode((int)HttpStatusCode.InternalServerError, "error while getting listing");
            }
        }
    }
}
