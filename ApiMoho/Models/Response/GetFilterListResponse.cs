using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMoho.Models.Dtos;

namespace ApiMoho.Models.Response
{
    public class GetFilterListResponse
    {
        public List<ListingDto> ListingTypes { get; set; }
        public  List<CountryDto> CountryList { get; set; }
    }
}
