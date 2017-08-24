using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMoho.Models.Enums;

namespace ApiMoho.Models.Dtos
{
    public class AddListingDto
    {
       public ListingTypeEnum ListingType { get; set; }
       public CountryEnum ListingCountry { get; set; }
       public ProvinceEnum ListingProvince { get; set; }
       public CityEnum ListingCity{ get; set; }
       public string ListingTitle{ get; set; }
       public string ListingDescription { get; set; }
       public string Address { get; set; }
       public string Email { get; set; }
       public string PhoneNumber { get; set; }
    }
}
