using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMoho.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiMoho.Context
{
    public class SecurityContext: IdentityDbContext<UserModel>
    {
        public SecurityContext(DbContextOptions<SecurityContext> options) : base(options)
        {
            
        }
    }
}
