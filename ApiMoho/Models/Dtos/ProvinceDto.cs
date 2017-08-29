using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMoho.Models.Dtos
{
    public class ProvinceDto
    {
        public string ProvinceName { get; set; }
        public int ProvinceType { get; set; }
        public List<CityDto> Cities { get; set; }
    }
}
