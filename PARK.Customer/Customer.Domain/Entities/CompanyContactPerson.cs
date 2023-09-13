using System;

namespace Domain.Entities
{
    public class CompanyContactPerson : BaseCrudEntity<Guid>
    {
        public Guid? CustomerId { get; set; }
        public Guid? PersonId { get; set; }
        public string Preferred { get; set; }


        public Customer Customer { get; set; }
        //public Customer Person { get; set; }
        public Person Person { get; set; }

    }
}
