using CustomerApp.Api.Models.SeedWork;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace Customer.Api.Models
{
    public class UserAddressModel : BaseCrudEntityModel<Guid>
    {
        public Guid UserID { get; set; }
        public Guid StreetID { get; set; }
        public Guid? CoordinatesID { get; set; }

        // Navigation properties
        public UserModel User { get; set; }
        public StreetModel Street { get; set; }
        public CoordinatesModel Coordinates { get; set; }
    }
}
