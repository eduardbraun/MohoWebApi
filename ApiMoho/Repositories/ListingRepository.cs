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
    }
}
