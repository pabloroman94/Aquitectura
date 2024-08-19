using CustomerApp.Api.Models.SeedWork;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Customer.Api.Models
{
    public class SubCategoryModel : BaseCrudEntityModel<Guid>
    {
        public string SubCategoryName { get; set; }
        public Guid CategoryID { get; set; }

        // Navigation properties
        public UserCategoryModel Category { get; set; }
        public ICollection<BusinessTypeModel> BusinessTypes { get; set; }
    }
}
