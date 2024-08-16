using CustomerApp.Api.Models.SeedWork;
using System;
using System.Collections.Generic;

namespace Customer.Api.Models
{
    public class CountryModel : BaseCrudEntityModel<Guid>
    {
        public string CountryName { get; set; }

        // A country can have multiple provinces
        //public IEnumerable<Province> Provinces { get; set; }
    }
}
