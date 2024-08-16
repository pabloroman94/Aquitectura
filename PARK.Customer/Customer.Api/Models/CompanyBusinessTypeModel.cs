using CustomerApp.Api.Models.SeedWork;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Customer.Api.Models
{
    public class CompanyBusinessTypeModel : BaseCrudEntityModel<Guid>
    {
        public Guid CompanyID { get; set; }
        public Guid BusinessTypeID { get; set; }

        // Navigation properties
        //public Company Company { get; set; }
        //public BusinessType BusinessType { get; set; }
    }
}
