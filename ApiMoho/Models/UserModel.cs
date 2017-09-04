using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMoho.Models
{
    public class UserModel : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime JobTitle { get; set; }
        public string Contract { get; set; }
        public byte[] AvatarImage { get; set; }
        public string Sex { get; set; }
        public string Location { get; set; }
        public string Age { get; set; }
        [DefaultValue(false)]
        public bool IsPremium { get; set; }
    }
}
