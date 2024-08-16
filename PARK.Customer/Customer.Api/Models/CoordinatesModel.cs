using CustomerApp.Api.Models.SeedWork;
using System;
using System.Collections.Generic;

namespace Customer.Api.Models
{
    public class CoordinatesModel : BaseCrudEntityModel<Guid>
    {
        public Guid UserAddressID { get; set; }
        public decimal Lng { get; set; }
        public decimal Lat { get; set; }
        public string GoogleMapsURL { get; set; }

        // Navigation Property
        //public UserAddressModel UserAddress { get; set; }
    }
}
