using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMoho.Models.Dtos;

namespace ApiMoho.Models.Response
{
    public class ViewListingResponse
    {
        public UserListingDto UserListing { get; set; }
        public UserProfileDto UserProfileDto { get; set; }
    }
}
