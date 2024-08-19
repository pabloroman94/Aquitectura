using CustomerApp.Api.Models.SeedWork;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Customer.Api.Models
{
    public class CoordinatesModel : BaseCrudEntityModel<Guid>
    {
        public decimal Lng { get; set; }  // Longitud
        public decimal Lat { get; set; }  // Latitud
        public string GoogleMapsURL { get; set; }

        // Navigation properties
        public UserAddressModel UserAddress { get; set; }
    }
}
