using CustomerApp.Api.Models.SeedWork;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Customer.Api.Models
{
    public class BusinessTypeModel : BaseCrudEntityModel<Guid>
    {
        public string TypeName { get; set; }
        public Guid CategoryID { get; set; }

        // Navigation properties
        //public CategoryModel Category { get; set; }
        //public ICollection<CompanyBusinessTypeModel> CompanyBusinessTypes { get; set; }
    }
}
