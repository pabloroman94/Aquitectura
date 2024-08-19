using CustomerApp.Api.Models.SeedWork;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Customer.Api.Models
{
    public class TagModel : BaseCrudEntityModel<Guid>
    {
        public string TagName { get; set; }

        // Navigation properties
        public ICollection<PersonTagModel> PersonTags { get; set; }
        public ICollection<CompanyTag> CompanyTags { get; set; }
    }
}
