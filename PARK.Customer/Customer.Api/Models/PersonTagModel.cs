using CustomerApp.Api.Models.SeedWork;
using Domain.Entities;
using System;

namespace Customer.Api.Models
{
    public class PersonTagModel : BaseCrudEntityModel<Guid>
    {
        public Guid PersonID { get; set; }
        public Guid TagID { get; set; }

        // Navigation properties
        //public PersonModel Person { get; set; }
        //public TagModel Tag { get; set; }
    }
}
