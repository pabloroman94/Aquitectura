using CustomerApp.Api.Models.SeedWork;
using Domain.Entities;
using System;

namespace Customer.Api.Models
{
    public class ClassificationModel : BaseCrudEntityModel<Guid>
    {
        public Guid CompanyID { get; set; }
        public Guid? CategoryID { get; set; }
        public Guid? SubCategoryID { get; set; }
        public Guid? BusinessTypeID { get; set; }

        // Navigation properties
        public UserCompanyModel Company { get; set; }
        public UserCategoryModel Category { get; set; }
        public SubCategoryModel SubCategory { get; set; }
        public BusinessTypeModel BusinessType { get; set; }
    }
}
