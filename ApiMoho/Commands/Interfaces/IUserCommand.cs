﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMoho.Models;
using ApiMoho.Models.Response;
using Microsoft.AspNetCore.Http;

namespace ApiMoho.Commands.Interfaces
{
    public interface IUserCommand
    {
        Task<GetUserProfileResponse> GetUserProfile(UserModel userModel);
    }
}
