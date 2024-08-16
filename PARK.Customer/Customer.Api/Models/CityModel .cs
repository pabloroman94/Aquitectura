using CustomerApp.Api.Models.SeedWork;
using System;
using System.Collections.Generic;

namespace Customer.Api.Models
{
    public class CityModel : BaseCrudEntityModel<Guid>
    {
        public string CityName { get; set; }
        public string PostalCode { get; set; }
        public Guid ProvinceID { get; set; }

        // Navigation Property
        //public ProvinceModel Province { get; set; }

        // A city can have multiple streets
        //public IEnumerable<StreetModel> Streets { get; set; }
    }
}
