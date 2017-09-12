using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMoho.Models
{
    public class SearchListingRequest
    {
        public int? FilterType { get; set; }
        public int? CountryType { get; set; }
        public int? ProvinceType { get; set; }
        public int? CityType { get; set; }
    }
}