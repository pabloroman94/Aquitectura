using CustomerApp.Api.Models.SeedWork;
using Domain.Entities;
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

        // Navigation properties
        public CityModel City { get; set; }
        public ICollection<UserAddressModel> UserAddresses { get; set; }
    }
}
