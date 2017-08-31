using System;
using System.Collections.Generic;

namespace ApiMoho.Models
{
    public partial class UserListings
    {
        public int UserListingId { get; set; }
        public string ListingName { get; set; }
        public string CountryName { get; set; }
        public string ProvinceName { get; set; }
        public string CityName { get; set; }
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
        public int? ListingTypeRefId { get; set; }
        public int? CountryRefId { get; set; }
        public int? ProvinceRefId { get; set; }
        public int? CityRefId { get; set; }
        public bool? ListingEnabled { get; set; }

        public AspNetUsers Owner { get; set; }
    }
}
