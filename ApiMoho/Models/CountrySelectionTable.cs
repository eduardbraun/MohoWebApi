using System;
using System.Collections.Generic;

namespace ApiMoho.Models
{
    public partial class CountrySelectionTable
    {
        public CountrySelectionTable()
        {
            CitySeleectionTable = new HashSet<CitySeleectionTable>();
            ProvinceSelectionTable = new HashSet<ProvinceSelectionTable>();
        }

        public int Id { get; set; }
        public string CountryName { get; set; }

        public ICollection<CitySeleectionTable> CitySeleectionTable { get; set; }
        public ICollection<ProvinceSelectionTable> ProvinceSelectionTable { get; set; }
    }
}
