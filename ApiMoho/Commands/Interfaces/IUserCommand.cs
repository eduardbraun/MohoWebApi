using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMoho.Models;
using ApiMoho.Models.Dtos;
using ApiMoho.Models.Request;
using ApiMoho.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ApiMoho.Commands.Interfaces
{
    public interface IUserCommand
    {
        Task<UserProfileDto> GetUserProfile(UserModel userModel);
        Task GiveUserReviewCommand(GiveReviewForUserRequest request, string userId, UserManager<UserModel> userManager);
    }
}
