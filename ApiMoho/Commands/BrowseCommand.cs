using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMoho.Commands.Interfaces;
using ApiMoho.Helper;
using ApiMoho.Models.Dtos;
using ApiMoho.Models.Response;
using ApiMoho.Repositories.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ApiMoho.Commands
{
    public class BrowseCommand:IBrowseCommand
    {
        private ILogger<ListingCommand> _logger;
        private IListingRepository _listingRepository;
        private IHttpContextAccessor _httpContextAccessor;

        public BrowseCommand(IListingRepository listingRepository, IHttpContextAccessor httpContextAccessor,
            ILogger<ListingCommand> logger)
        {
            _httpContextAccessor = httpContextAccessor;
            _listingRepository = listingRepository;
            _logger = logger;
        }

        public async Task<ViewListingResponse> ViewListing(int id)
        {
            try
            {
                var listing = await _listingRepository.GetById(id);

                var listingDto = new UserListingDto
                {
                    Address = listing.Address,
                    ListingType = EnumHelper.GetListingEnumString((int)listing.ListingTypeRefId),
                    City = EnumHelper.GetCityEnumString((int)listing.CityRefId),
                    Country = EnumHelper.GetCountryEnumString((int)listing.CountryRefId),
                    Province = EnumHelper.GetProvinceEnumString((int)listing.ProvinceRefId),
                    Email = listing.Email,
                    FullName = listing.FullName,
                    PhoneNumber = listing.PhoneNumber,
                    LastUpdatedDate = listing.LastUpdatedDate,
                    ListingDate = listing.ListingDate,
                    ListingDescription = listing.ListingDescription,
                    ListingTitle = listing.ListingTitle,
                    UserListingId = listing.UserListingId,
                    OwnerId = listing.OwnerId,
                    Views = listing.Views,
                    ListingEnabled = listing.ListingEnabled
                };
                var listingResponse = new ViewListingResponse()
                {
                    UserListing = listingDto
                };

                return listingResponse;
            }
            catch (Exception e)
            {
                _logger.LogError($"error while getting listing: {e}");
                throw e.GetBaseException();
            }
        }
    }
}
