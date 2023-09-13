using CustomerApp.Api.Models.SeedWork;
using System;
using System.Collections.Generic;

namespace Customer.Api.Models
{
    public class CompanyContactPersonModel : BaseCrudEntityModel<Guid>
    {
        public Guid? CustomerId { get; set; }
        public Guid? PersonId { get; set; }
        public string Preferred { get; set; }
        //public CustomerModel Person { get; set; }
        public PersonModel Person { get; set; }
    }
}