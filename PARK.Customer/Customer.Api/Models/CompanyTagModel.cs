using CustomerApp.Api.Models.SeedWork;
using Domain.Entities;
using System;

namespace Customer.Api.Models
{
    public class CompanyTagModel : BaseCrudEntityModel<Guid>
    {
        public Guid CompanyID { get; set; }
        public Guid TagID { get; set; }

        // Navigation properties
        //public UserCompanyModel Company { get; set; }
        //public TagModel Tag { get; set; }
    }
}
