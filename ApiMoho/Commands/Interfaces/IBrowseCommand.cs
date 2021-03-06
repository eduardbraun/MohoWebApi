﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMoho.Models;
using ApiMoho.Models.Response;
using Microsoft.AspNetCore.Identity;

namespace ApiMoho.Commands.Interfaces
{
    public interface IBrowseCommand
    {
        Task<ViewListingResponse> ViewListing(int id, UserManager<UserModel> _userManager);
    }
}
