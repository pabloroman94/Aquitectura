using CustomerApp.Api.Models.SeedWork;
using Domain.Entities;
using System;

namespace Customer.Api.Models
{
    public class UserCategoryModel : BaseCrudEntityModel<Guid>
    {
        public Guid UserID { get; set; }
        public Guid CategoryID { get; set; }

        // Navigation properties
        //public User User { get; set; }
        //public Category Category { get; set; }
    }
}
