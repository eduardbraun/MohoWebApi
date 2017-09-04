using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ApiMoho.Commands.Interfaces;
using ApiMoho.Models;
using ApiMoho.Models.Dtos;
using ApiMoho.Models.Response;
using ApiMoho.Repositories.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ApiMoho.Commands
{
    public class UserCommand : IUserCommand
    {
        private IUserRepository _userRepository;
        public UserCommand(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<GetUserProfileResponse> GetUserProfile(UserModel userModel)
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

                return new GetUserProfileResponse()
                {
                  UserProfileDto = user
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
