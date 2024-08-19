using CustomerApp.Api.Models.SeedWork;
using Domain.Entities;
using System;

namespace Customer.Api.Models
{
    public class PersonProfessionModel : BaseCrudEntityModel<Guid>
    {
        public Guid PersonID { get; set; }
        public Guid ProfessionID { get; set; }

        // Navigation properties
        public UserPerson Person { get; set; }
        public Profession Profession { get; set; }
    }
}
