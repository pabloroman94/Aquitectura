using CustomerApp.Api.Models.SeedWork;
using Domain.Entities;
using System;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Customer.Api.Models
{
    public class UserCompanyModel : UserModel// BaseCrudEntityModel<Guid>
    {
        public string CompanyName { get; set; }

        // Navigation properties
        public ICollection<ClassificationModel> Classifications { get; set; }
        public ICollection<CompanyTagModel> CompanyTags { get; set; }
    }
} 
