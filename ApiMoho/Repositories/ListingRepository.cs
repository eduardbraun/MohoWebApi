﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ApiMoho.Models;
using ApiMoho.Models.Dtos;
using ApiMoho.Models.Request;
using ApiMoho.Repositories.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ApiMoho.Repositories
{
    public class ListingRepository:IListingRepository
    {
        private ILogger<ListingRepository> _logger;
        public ListingRepository(ILogger<ListingRepository> logger)
        {
            _logger = logger;
        }
        public async Task<UserListings> AddListing(UserListings userListings)
        {
            try
            {
                using (ApiMohoContext context = new ApiMohoContext())
                {
                    var result =  await context.UserListings.AddAsync(userListings);
                    await context.SaveChangesAsync();

                    var userlisting = result.Entity;

                    return userlisting;
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public Task RemoveListing(int enity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserListings>> GetAll()
        {
            using (ApiMohoContext context = new ApiMohoContext())
            {
                try
                {
                    var userListings = await context.UserListings.Where(a=> a.ListingEnabled == true).ToListAsync();
                    return userListings;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"error while getting list from database: {ex}");
                    throw ex.GetBaseException();
                }
            }
        }

        public async Task<UserListings> GetById(int id)
        {
            try
            {
                using (var context = new ApiMohoContext())
                {
                    var listing = await context.UserListings.FindAsync(id);
                    if (listing != null)
                    {
                        if (listing.Views == null)
                        {
                            listing.Views = 1;
                        }
                        else
                        {
                            listing.Views += 1;
                        }
                        await context.SaveChangesAsync();
                        return listing;
                    }

                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<UserListings>> GetAllForUser(string ownerId)
        {
            using (ApiMohoContext context = new ApiMohoContext())
            {
                try
                {
                    var userListings = await context.UserListings.Where(id => id.OwnerId == ownerId).ToListAsync();
                    return userListings;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"error while getting list from database: {ex}");
                    throw ex.GetBaseException();
                }
            }
        }

        public async Task<UserListings> Update(UserListings userListings, string ownerId)
        {
            try
            {
                using (ApiMohoContext context = new ApiMohoContext())
                {
                    var userListing = await context.UserListings.SingleAsync(id => id.UserListingId == userListings.UserListingId && id.OwnerId == ownerId);

                    userListing.CityRefId = userListings.CityRefId;
                    userListing.ListingTypeRefId = userListings.ListingTypeRefId;
                    userListing.CountryRefId = userListings.CountryRefId;
                    userListing.ProvinceRefId = userListings.ProvinceRefId;
                    userListing.ListingName = userListings.ListingName;
                    userListing.CountryName = userListings.CountryName;
                    userListing.ProvinceName = userListings.ProvinceName;
                    userListing.CityName = userListings.CityName;
                    userListing.LastUpdatedDate = DateTime.Now;
                    userListing.ListingDescription = userListings.ListingDescription;
                    userListing.ListingTitle = userListings.ListingTitle;
                    userListing.PhoneNumber = userListings.PhoneNumber;
                    userListing.Email = userListings.Email;
                    userListing.FullName = userListings.FullName;
                    userListing.Address = userListings.Address;

                    await context.SaveChangesAsync();

                    return userListing;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"error while updateing listing from database: {ex}");
                throw ex.GetBaseException();
            }
        }

        public async Task<List<CountrySelectionTable>> GetAllCounties()
        {
            try
            {
                using (ApiMohoContext context = new ApiMohoContext())
                {
                    var countries = await context.CountrySelectionTable.ToListAsync();

                    return countries;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"error while getting all countries from database: {ex}");
                throw ex.GetBaseException();
            }
        }

        public async Task<List<ProvinceSelectionTable>> GetAllProvinces()
        {
            try
            {
                using (ApiMohoContext context = new ApiMohoContext())
                {
                    var provinces = await context.ProvinceSelectionTable.ToListAsync();

                    return provinces;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"error while getting all provinces from database: {ex}");
                throw ex.GetBaseException();
            }
        }

        public async Task<List<CitySeleectionTable>> GetAllCities()
        {
            try
            {
                using (ApiMohoContext context = new ApiMohoContext())
                {
                    var cities = await context.CitySeleectionTable.ToListAsync();

                    return cities;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"error while getting all cities from database: {ex}");
                throw ex.GetBaseException();
            }
        }

        public async Task<List<ListingSelectionTable>> GetAllListings()
        {
            try
            {
                using (ApiMohoContext context = new ApiMohoContext())
                {
                    var listings = await context.ListingSelectionTable.ToListAsync();
                    return listings;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"error while getting all listings from database: {ex}");
                throw ex.GetBaseException();
            }
        }

        public async Task DeleteListing(int listingId, string ownderId)
        {
            using (var context = new ApiMohoContext())
            {
                var listing = await context.UserListings.FindAsync(listingId);
                if (listing != null)
                {
                    var del = context.UserListings.Remove(listing);

                    await context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("No Listing was found by the given id {listingId}");
                }
            }
        }

        public async Task SetListingStatus(int listingId, string ownderId, bool enabled)
        {
            using (var context = new ApiMohoContext())
            {
                var listing = await context.UserListings.FindAsync(listingId);
                if (listing != null)
                {
                    listing.ListingEnabled = enabled;

                   await context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("No Listing was found by the given id {listingId}");
                }
            }
        }

        public async Task<List<UserListings>> SearchFilter(SearchListingRequest searchListingRequest)
        {
            try
            {
                using (var context  = new ApiMohoContext())
                {
                    if (searchListingRequest.CityType != null && searchListingRequest.CountryType != null &&
                        searchListingRequest.FilterType != null && searchListingRequest.ProvinceType != null)
                    {
                        var userListings = await context.UserListings.Where(a => a.ListingEnabled == true && a.ListingTypeRefId == searchListingRequest.FilterType
                        && a.CountryRefId == searchListingRequest.CountryType && a.ProvinceRefId == searchListingRequest.ProvinceType
                        && a.CityRefId == searchListingRequest.CityType).ToListAsync();
                        return userListings;
                    }
                    else if (searchListingRequest.CountryType != null &&
                        searchListingRequest.FilterType != null && searchListingRequest.ProvinceType != null)
                    {
                        var userListings = await context.UserListings.Where(a => a.ListingEnabled == true && a.ListingTypeRefId == searchListingRequest.FilterType
                                                                                 && a.CountryRefId == searchListingRequest.CountryType && a.ProvinceRefId == searchListingRequest.ProvinceType).ToListAsync();
                        return userListings;
                    }
                    else if (searchListingRequest.CountryType != null &&
                        searchListingRequest.FilterType != null)
                    {
                        var userListings = await context.UserListings.Where(a => a.ListingEnabled == true && a.ListingTypeRefId == searchListingRequest.FilterType
                                                                                 && a.CountryRefId == searchListingRequest.CountryType).ToListAsync();
                        return userListings;
                    }
                    else if (searchListingRequest.FilterType != null)
                    {
                        var userListings = await context.UserListings.Where(a => a.ListingEnabled == true && a.ListingTypeRefId == searchListingRequest.FilterType).ToListAsync();
                        return userListings;
                    }
                    else
                    {
                        var userListings = await context.UserListings.Where(a => a.ListingEnabled == true).ToListAsync();
                        return userListings;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
