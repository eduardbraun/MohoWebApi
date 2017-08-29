using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ApiMoho.Commands.Interfaces;
using ApiMoho.Helper;
using ApiMoho.Models;
using ApiMoho.Models.Dtos;
using ApiMoho.Models.Enums;
using ApiMoho.Models.Request;
using ApiMoho.Models.Response;
using ApiMoho.Repositories.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiMoho.Commands
{
    public class ListingCommand : IListingCommand
    {
        private ILogger<ListingCommand> _logger;
        private IListingRepository _listingRepository;
        private IHttpContextAccessor _httpContextAccessor;
        public ListingCommand(IListingRepository listingRepository, IHttpContextAccessor httpContextAccessor, ILogger<ListingCommand> logger)
        {
            _httpContextAccessor = httpContextAccessor;
            _listingRepository = listingRepository;
            _logger = logger;
        }

        public async Task<UserListingDto> AddListingCommand(AddListingDto addListingDto, string UserFullName, string UserId)
        {
            try
            {
                var listing = new UserListings
                {
                    CountryRefId = (int)addListingDto.ListingCountry,
                    ProvinceRefId = (int)addListingDto.ListingProvince,
                    CityRefId = (int)addListingDto.ListingCity,
                    ListingTypeRefId = (int)addListingDto.ListingType,
                    CountryName = EnumHelper.GetCityEnumString((int)addListingDto.ListingCountry),
                    ProvinceName = EnumHelper.GetProvinceEnumString((int)addListingDto.ListingProvince),
                    CityName = EnumHelper.GetCityEnumString((int)addListingDto.ListingCity),
                    ListingName = EnumHelper.GetListingEnumString((int)addListingDto.ListingType),
                    ListingDescription = addListingDto.ListingDescription,
                    ListingTitle = addListingDto.ListingTitle,
                    Address = addListingDto.Address,
                    Email = addListingDto.Email,
                    PhoneNumber = addListingDto.PhoneNumber,
                    FullName = UserFullName,
                    OwnerId = UserId,
                    ListingDate = DateTime.Today,
                    LastUpdatedDate = DateTime.Today
                };

                var addListing = await _listingRepository.AddListing(listing);

                var newListing = new UserListingDto
                {
                    Address = addListing.Address,
                    City = EnumHelper.GetCityEnumString((int)addListing.CityRefId),
                    Country = EnumHelper.GetCountryEnumString((int)addListing.CountryRefId),
                    Province = EnumHelper.GetProvinceEnumString((int)addListing.ProvinceRefId),
                    Email = addListing.Email,
                    FullName = addListing.FullName,
                    LastUpdatedDate = addListing.LastUpdatedDate,
                    ListingDate = addListing.ListingDate,
                    ListingDescription = addListing.ListingDescription,
                    ListingTitle = addListing.ListingTitle,
                    ListingType = EnumHelper.GetListingEnumString((int)addListing.ListingTypeRefId),
                    UserListingId = addListing.UserListingId,
                    OwnerId = addListing.OwnerId
                };

                return newListing;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public async Task<UserListingCollectionDto> GetAllListingsCommand()
        {
            try
            {
                var listings = await _listingRepository.GetAll();

                var allListingDto = new UserListingCollectionDto();
                allListingDto.ListingsCollection = new List<UserListingDto>();

                var lis = new List<UserListingDto>();

                foreach (var listing in listings)
                {
                    var listingDto = new UserListingDto
                    {
                        Address = listing.Address,
                        ListingType = EnumHelper.GetListingEnumString((int)listing.ListingTypeRefId),
                        City = EnumHelper.GetCityEnumString((int)listing.CityRefId),
                        Country = EnumHelper.GetCountryEnumString((int)listing.CountryRefId),
                        Province = EnumHelper.GetProvinceEnumString((int)listing.ProvinceRefId),
                        Email = listing.Email,
                        FullName = listing.FullName,
                        LastUpdatedDate = listing.LastUpdatedDate,
                        ListingDate = listing.ListingDate,
                        ListingDescription = listing.ListingDescription,
                        ListingTitle = listing.ListingTitle,
                        UserListingId = listing.UserListingId,
                        OwnerId = listing.OwnerId
                    };

                    allListingDto.ListingsCollection.Add(listingDto);
                }
                return allListingDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error while constructing listing list: {ex}");
                throw ex.GetBaseException();
            }
        }

        public async Task<UserListingCollectionDto> GetAllListingsForUserCommand(string userId)
        {
            try
            {
                var listings = await _listingRepository.GetAllForUser(userId);

                var allListingDto = new UserListingCollectionDto();
                allListingDto.ListingsCollection = new List<UserListingDto>();

                var lis = new List<UserListingDto>();

                foreach (var listing in listings)
                {
                    var listingDto = new UserListingDto
                    {
                        Address = listing.Address,
                        ListingType = EnumHelper.GetListingEnumString((int)listing.ListingTypeRefId),
                        City = EnumHelper.GetCityEnumString((int)listing.CityRefId),
                        Country = EnumHelper.GetCountryEnumString((int)listing.CountryRefId),
                        Province = EnumHelper.GetProvinceEnumString((int)listing.ProvinceRefId),
                        Email = listing.Email,
                        FullName = listing.FullName,
                        LastUpdatedDate = listing.LastUpdatedDate,
                        ListingDate = listing.ListingDate,
                        ListingDescription = listing.ListingDescription,
                        ListingTitle = listing.ListingTitle,
                        UserListingId = listing.UserListingId,
                        OwnerId = listing.OwnerId
                    };

                    allListingDto.ListingsCollection.Add(listingDto);
                }
                return allListingDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error while constructing all user listing list: {ex}");
                throw ex.GetBaseException();
            }
        }

        public async Task<UserListingDto> UpdateListing(UpdateListingRequest updateListingRequest, string userId)
        {
            try
            {
                CountryEnum c;
                var listing = new UserListings
                {
                    CountryName = updateListingRequest.ListingCountry,
                    ProvinceName = updateListingRequest.ListingProvince,
                    CityName = updateListingRequest.ListingCity,
                    ListingName = updateListingRequest.ListingType,
                    ListingDescription = updateListingRequest.ListingDescription,
                    ListingTitle = updateListingRequest.ListingTitle,
                    Address = updateListingRequest.Address,
                    Email = updateListingRequest.Email,
                    PhoneNumber = updateListingRequest.PhoneNumber,
                    FullName = updateListingRequest.FullName,
                    OwnerId = updateListingRequest.OwnerId,
                    LastUpdatedDate = DateTime.Today,
                    CityRefId = EnumHelper.GetCityEnumInt(updateListingRequest.ListingCity),
                    CountryRefId = EnumHelper.GetCountryEnumInt(updateListingRequest.ListingCountry),
                    ProvinceRefId = EnumHelper.GetProvinceEnumInt(updateListingRequest.ListingProvince),
                    ListingTypeRefId = EnumHelper.GetListingEnumInt(updateListingRequest.ListingType),
                };

                var addListing = await _listingRepository.Update(listing, userId);
               

                var newListing = new UserListingDto
                {
                    Address = addListing.Address,
                    City = EnumHelper.GetCityEnumString((int)addListing.CityRefId),
                    Country = EnumHelper.GetCountryEnumString((int)addListing.CountryRefId),
                    Province = EnumHelper.GetProvinceEnumString((int)addListing.ProvinceRefId),
                    Email = addListing.Email,
                    FullName = addListing.FullName,
                    LastUpdatedDate = addListing.LastUpdatedDate,
                    ListingDate = addListing.ListingDate,
                    ListingDescription = addListing.ListingDescription,
                    ListingTitle = addListing.ListingTitle,
                    ListingType = EnumHelper.GetListingEnumString((int)addListing.ListingTypeRefId),
                    UserListingId = addListing.UserListingId,
                    OwnerId = addListing.OwnerId
                };

                return newListing;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public async Task<GetFilterListResponse> GetFilterList()
        {
            try
            {
                var countries = await _listingRepository.GetAllCounties();
                var provinces = await _listingRepository.GetAllProvinces();
                var listingtypes = await _listingRepository.GetAllListings();
                var cities = await _listingRepository.GetAllCities();

                GetFilterListResponse filterListResponse = new GetFilterListResponse();
                filterListResponse.CountryList = new List<CountryDto>();
                filterListResponse.ListingTypes = new List<ListingDto>();

                foreach (var listingType in listingtypes)
                {
                    ListingDto listingDto = new ListingDto()
                    {
                        ListingFilterName = listingType.ListingName,
                        ListingType = listingType.Id
                    };

                    filterListResponse.ListingTypes.Add(listingDto);
                }

                foreach (var country in countries)
                {
                    var countryDto = new CountryDto();

                    countryDto.CountryType = country.Id;
                    countryDto.CountryName = country.CountryName;
                    countryDto.Provinces = new List<ProvinceDto>();

                    foreach (var province in provinces)
                    {
                        if (province.CountryRefId == country.Id)
                        {
                            var provinceDto = new ProvinceDto();
                            provinceDto.Cities = new List<CityDto>();
                            provinceDto.ProvinceType = province.Id;
                            provinceDto.ProvinceName = province.ProvinceName;

                            foreach (var city in cities)
                            {
                                if (city.CountryRefId == country.Id && city.ProvinceRefId == province.Id)
                                {
                                    var cityDto = new CityDto()
                                    {
                                        CityName = city.RegionName,
                                        CityType = city.Id
                                    };

                                    provinceDto.Cities.Add(cityDto);
                                }
                            }
                            countryDto.Provinces.Add(provinceDto);
                        }
                    }
                    filterListResponse.CountryList.Add(countryDto);
                }
                return filterListResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError($"error while constructing filter list: {ex}");
                throw ex.GetBaseException();
            }
        }
    }
}