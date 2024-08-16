using CustomerApp.Api.Models.SeedWork;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace Customer.Api.Models
{
    public class ProvinceModel : BaseCrudEntityModel<Guid>
    {
        public string ProvinceName { get; set; }
        public Guid CountryID { get; set; }

        // Navigation Property
        //public CountryModel Country { get; set; }

        // A province can have multiple cities
        //public IEnumerable<CityModel> Cities { get; set; }
    }
}
