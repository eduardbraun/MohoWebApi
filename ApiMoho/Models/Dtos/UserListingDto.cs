using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMoho.Models.Dtos
{
    public class UserListingDto
    {
        public int UserListingId { get; set; }
        public String ListingType { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string OwnerId { get; set; }
        public DateTime? ListingDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string ListingDescription { get; set; }
        public string ListingTitle { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public bool? ListingEnabled { get; set; }
    }
}
