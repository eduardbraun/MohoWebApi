﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ApiMoho.Commands.Interfaces;
using ApiMoho.Helper;
using ApiMoho.Models;
using ApiMoho.Models.Dtos;
using ApiMoho.Models.Enums;
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
                    CountryType = (int)addListingDto.ListingCountry,
                    ProvinceType = (int)addListingDto.ListingProvince,
                    CityType = (int)addListingDto.ListingCity,
                    ListingType = (int)addListingDto.ListingType,
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

                var a = addListing;

                var newListing = new UserListingDto
                {
                    Address = addListing.Address,
                    City = EnumHelper.GetCityEnumString((int)addListingDto.ListingCity),
                    Country = EnumHelper.GetCountryEnumString((int)addListingDto.ListingCountry),
                    Province = EnumHelper.GetProvinceEnumString((int)addListingDto.ListingProvince),
                    Email = addListing.Email,
                    FullName = addListing.FullName,
                    LastUpdatedDate = addListing.LastUpdatedDate,
                    ListingDate = addListing.ListingDate,
                    ListingDescription = addListing.ListingDescription,
                    ListingTitle = addListing.ListingTitle,
                    ListingType = EnumHelper.GetListingEnumString((int)addListingDto.ListingType),
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
                        ListingType = EnumHelper.GetListingEnumString((int)listing.ListingType),
                        City = EnumHelper.GetCityEnumString((int)listing.CityType),
                        Country = EnumHelper.GetCountryEnumString((int)listing.CountryType),
                        Province = EnumHelper.GetProvinceEnumString((int)listing.ProvinceType),
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
    }
}