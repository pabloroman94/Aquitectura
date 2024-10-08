﻿using CustomerApp.Api.Models.SeedWork;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace Customer.Api.Models
{
    public class ProvinceModel : BaseCrudEntityModel<Guid>
    {
        public string ProvinceName { get; set; }
        public Guid CountryID { get; set; }

        // Navigation properties
        public CountryModel Country { get; set; }
        public ICollection<CityModel> Cities { get; set; }
    }
}
