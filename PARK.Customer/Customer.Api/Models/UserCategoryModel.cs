using CustomerApp.Api.Models.SeedWork;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Customer.Api.Models
{
    public class UserCategoryModel : BaseCrudEntityModel<Guid>
    {
        public string CategoryName { get; set; }

        // Navigation properties
        public ICollection<ProfessionModel> Professions { get; set; }  // Una categoría puede tener muchas profesiones
        //public IEnumerable<CompanyCategory> CompanyCategories { get; set; }
        public ICollection<SubCategoryModel> SubCategories { get; set; }
    }
}
