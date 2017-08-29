using System;
using System.Collections.Generic;

namespace ApiMoho.Models
{
    public partial class CitySeleectionTable
    {
        public int Id { get; set; }
        public string RegionName { get; set; }
        public int CountryRefId { get; set; }
        public int ProvinceRefId { get; set; }

        public CountrySelectionTable CountryRef { get; set; }
        public ProvinceSelectionTable ProvinceRef { get; set; }
    }
}
