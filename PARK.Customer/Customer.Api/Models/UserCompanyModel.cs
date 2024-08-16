using CustomerApp.Api.Models.SeedWork;
using Domain.Entities;
using System;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Customer.Api.Models
{
    public class UserCompanyModel : BaseCrudEntityModel<Guid>
    {
        public string CompanyName { get; set; }

        // Navigation properties
        //public UserModel User { get; set; }
        //public IEnumerable<CompanyCategoryModel> CompanyCategories { get; set; }
        //public IEnumerable<CompanyTagModel> CompanyTags { get; set; }
    }
} 
