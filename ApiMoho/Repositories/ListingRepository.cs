using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ApiMoho.Models;
using ApiMoho.Models.Dtos;
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

        public async Task RemoveListing(int enity)
        {
     
        }

        public async Task<List<UserListings>> GetAll()
        {
            using (ApiMohoContext context = new ApiMohoContext())
            {
                try
                {
                    var userListings = context.UserListings.ToList();
                    return userListings;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"error while getting list from database: {ex}");
                    throw ex.GetBaseException();
                }
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
                    UserListings userListing = await context.UserListings.FirstAsync(id => id.UserListingId == userListings.UserListingId && id.OwnerId == ownerId);

                    userListing.CityType = userListings.CityType;
                    userListing.ListingType = userListings.ListingType;
                    userListing.CountryType = userListings.CountryType;
                    userListing.ProvinceType = userListings.ProvinceType;
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
                throw ex.InnerException;
            }
        }
    }
}
