using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMoho.Models
{
    public class UserModel : IdentityUser
    {
        public DateTime JoinDate { get; set; }
        public DateTime JobTitle { get; set; }
        public string Contract { get; set; }
    }
}
