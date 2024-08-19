using CustomerApp.Api.Models.SeedWork;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Customer.Api.Models
{
    public class ProfessionModel : BaseCrudEntityModel<Guid>
    {
        public string ProfessionName { get; set; }
        public Guid CategoryID { get; set; }

        // Navigation properties
        //public CategoryModel Category { get; set; }
        //public IEnumerable<PersonProfessionModel> PersonProfessions { get; set; }
    }
}
