﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMoho.Context;
using ApiMoho.Models;
using ApiMoho.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ApiMoho.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ILogger<UserRepository> _logger;
        public UserRepository(ILogger<UserRepository> logger)
        {
            _logger = logger;
        }
        public async Task AddUserReview(UserReview userReview)
        {
            try
            {
                using (var context = new ApiMohoContext())
                {
                    var usr = await context.UserReview.AddAsync(userReview);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"error while saving user review to database: {ex}");
                throw ex.GetBaseException();
            }
        }

        public async Task<List<UserReview>> GetUserReviewList(string userId)
        {
            try
            {
                using (var context = new ApiMohoContext())
                {
                    var userReviews = await context.UserReview.Where(a => a.UserRefId == userId && a.ReviewDeleted != true).ToListAsync();

                    return userReviews;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"error while getting user reviews from database: {ex}");
                throw ex.GetBaseException();
            }
        }
    }
}
