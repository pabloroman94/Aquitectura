using CustomerApp.Api.Models.SeedWork;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Customer.Api.Models
{
    public class BusinessTypeModel : BaseCrudEntityModel<Guid>
    {
        public string TypeName { get; set; }
        public Guid SubCategoryID { get; set; }

        // Navigation properties
        public SubCategoryModel SubCategory { get; set; }
        public ICollection<ClassificationModel> Classifications { get; set; }
    }
}
