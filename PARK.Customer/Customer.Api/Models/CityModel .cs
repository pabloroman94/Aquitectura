using CustomerApp.Api.Models.SeedWork;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Customer.Api.Models
{
    public class CityModel : BaseCrudEntityModel<Guid>
    {
        public string CityName { get; set; }
        public string PostalCode { get; set; }
        public Guid ProvinceID { get; set; }

        // Navigation properties
        public ProvinceModel Province { get; set; }
        public ICollection<StreetModel> Streets { get; set; }
    }
}
