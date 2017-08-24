using System;
using System.Collections.Generic;

namespace ApiMoho.Models
{
    public partial class UserListings
    {
        public int UserListingId { get; set; }
        public int ListingType { get; set; }
        public int CountryType { get; set; }
        public int ProvinceType { get; set; }
        public int CityType { get; set; }
        public string OwnerId { get; set; }
        public DateTime? ListingDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string ListingDescription { get; set; }
        public string ListingTitle { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public int? Views { get; set; }

        public AspNetUsers Owner { get; set; }
    }
}
