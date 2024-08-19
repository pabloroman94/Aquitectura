using CustomerApp.Api.Models.SeedWork;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Customer.Api.Models
{
    public class CountryModel : BaseCrudEntityModel<Guid>
    {
        public string CountryName { get; set; }

        // Navigation properties
        public ICollection<ProvinceModel> Provinces { get; set; }
    }
}
