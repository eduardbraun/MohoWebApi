using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMoho.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ApiMoho.Services
{
    public class UserResolverService
    {
        private readonly IHttpContextAccessor _context;
        private readonly UserManager<UserModel> _userManager;
        public UserResolverService(IHttpContextAccessor context, UserManager<UserModel> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<UserModel> GetUser()
        {
            return await _userManager.FindByEmailAsync(_context.HttpContext.User?.Identity?.Name);
        }
    }
}
