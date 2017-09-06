using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ApiMoho.Commands.Interfaces;
using ApiMoho.Models;
using ApiMoho.Models.Dtos;
using ApiMoho.Models.Request;
using ApiMoho.Models.Response;
using ApiMoho.Repositories;
using ApiMoho.Repositories.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace ApiMoho.Commands
{
    public class UserCommand : IUserCommand
    {
        private ILogger<UserCommand> _logger;
        private IUserRepository _userRepository;
        public UserCommand(IUserRepository userRepository, ILogger<UserCommand> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }


        public async Task<UserProfileDto> GetUserProfile(UserModel userModel)
        {
            try
            {
                var user = new UserProfileDto()
                {
                    AvatarImage = userModel.AvatarImage,
                    Email = userModel.Email,
                    FirstName = userModel.FirstName,
                    LastName = userModel.LastName,
                    UserName = userModel.UserName,
                    UserId = userModel.Id
                };

                return user;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task GiveUserReviewCommand(GiveReviewForUserRequest request, string userId, UserManager<UserModel> userManager)
        {
            try
            {
                var user = await userManager.FindByIdAsync(userId);
                var review = new UserReview()
                {
                    ReviewDate = DateTime.Now,
                    ReviewDescription = request.ReviewDescription,
                    UserRefId = request.OwnerId,
                    ReviewOwnerRefId = userId,
                    ReviewTitle = request.ReviewTitle,
                    UpVoteNum = Convert.ToString(request.UpVotePoints),
                    ReviewUsername = user.UserName
                };

                await _userRepository.AddUserReview(review);

                user.UpVote += request.UpVotePoints;

                await userManager.UpdateAsync(user);
            }
            catch (Exception ex)
            {
                _logger.LogError($"error while saving user review to database: {ex}");
                throw ex.GetBaseException();
            }
        }
    }
}
