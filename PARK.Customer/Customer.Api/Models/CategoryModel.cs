using CustomerApp.Api.Models.SeedWork;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Customer.Api.Models
{
    public class CategoryModel : BaseCrudEntityModel<Guid>
    {
        public string CategoryName { get; set; }

        // Navigation properties
        //public IEnumerable<ProfessionModel> Professions { get; set; }
        //public IEnumerable<CompanyCategoryModel> CompanyCategories { get; set; }
    }
}
