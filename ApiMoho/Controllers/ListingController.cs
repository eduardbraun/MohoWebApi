using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ApiMoho.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiMoho.Controllers
{
    [Produces("application/json")]
    [Route("api/Listing")]
    public class ListingController : Controller
    {
        private ILogger<ListingController> _logger;

        public ListingController(ILogger<ListingController> logger)
        {
            _logger = logger;
        }
        [HttpPost("NewListing")]
        [Route("token")]
        public async Task<IActionResult> NewListing([FromForm] AddListingDto addListingDto)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"error while creating listing: {ex}");
                return StatusCode((int)HttpStatusCode.InternalServerError, "error while creating listing");
            }
        }
       
    }
}