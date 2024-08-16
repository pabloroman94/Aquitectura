using CustomerApp.Api.Models.SeedWork;
using System;
using System.Collections.Generic;

namespace Customer.Api.Models
{
    public class TagModel : BaseCrudEntityModel<Guid>
    {
        public string TagName { get; set; }

        // Navigation properties
        //public IEnumerable<PersonTagModel> PersonTags { get; set; }
        //public IEnumerable<CompanyTagModel> CompanyTags { get; set; }
    }
}
