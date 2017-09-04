using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMoho.Models.Dtos;

namespace ApiMoho.Models.Response
{
    public class GetUserProfileResponse
    {
        public UserProfileDto UserProfileDto { get; set; }
    }
}
