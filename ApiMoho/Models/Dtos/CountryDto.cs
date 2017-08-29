using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMoho.Models.Dtos
{
    public class CountryDto
    {
        public string CountryName { get; set; }
        public int CountryType { get; set; }
        public List<ProvinceDto> Provinces { get; set; }
    }
}
