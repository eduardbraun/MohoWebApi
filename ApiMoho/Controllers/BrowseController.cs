using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly UserManager<UserModel> _userManager;

        public BrowseController(ILogger<ListingController> logger, IListingCommand listingCommand,
            UserManager<UserModel> userManager)
        {
            _logger = logger;
            _listingCommand = listingCommand;
            _userManager = userManager;
        }

        [AllowAnonymous]
        [HttpGet("id={id}")]
        public async Task<IActionResult> GetListingView(int id)
        {

        }
    }
}
