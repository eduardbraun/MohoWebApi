using System;
using System.Collections.Generic;

namespace ApiMoho.Models
{
    public partial class ProvinceSelectionTable
    {
        public ProvinceSelectionTable()
        {
            CitySeleectionTable = new HashSet<CitySeleectionTable>();
        }

        public int Id { get; set; }
        public string ProvinceName { get; set; }
        public int? CountryRefId { get; set; }

        public CountrySelectionTable CountryRef { get; set; }
        public ICollection<CitySeleectionTable> CitySeleectionTable { get; set; }
    }
}
