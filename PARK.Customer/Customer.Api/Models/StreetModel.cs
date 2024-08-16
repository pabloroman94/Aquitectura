using CustomerApp.Api.Models.SeedWork;
using System;
using System.Collections.Generic;

namespace Customer.Api.Models
{
    public class StreetModel : BaseCrudEntityModel<Guid>
    {
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string Floor { get; set; }
        public Guid CityID { get; set; }

        // Navigation Property
        //public CityModel City { get; set; }

        // A street can have multiple user addresses
        //public IEnumerable<UserAddressModel> UserAddresses { get; set; }
    }
}
