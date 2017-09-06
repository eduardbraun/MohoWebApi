using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace ApiMoho.Models.Dtos
{
    public class UserProfileDto
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public byte[] AvatarImage { get; set; }
        public int UpVote { get; set; }
    }
}
