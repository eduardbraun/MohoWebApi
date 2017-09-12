using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ApiMoho.Models.Enums;

namespace ApiMoho.Models
{
    public class UpdateListingRequest
    {
        [Required]
        public int UserListingId { get; set; }
        [Required]
        public string OwnerId { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string ListingType { get; set; }
        [Required]
        public string ListingCountry { get; set; }
        [Required]
        public string ListingProvince { get; set; }
        [Required]
        public string ListingCity { get; set; }
        [Required]
        public string ListingTitle { get; set; }
        [Required]
        public string Email { get; set; }
        public string ListingDescription { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}