using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Mail : BaseCrudEntity<Guid>
    {
        public Customer Customer { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? ContactTypeId { get; set; }
        public string Email { get; set; }
        public int? Preferred { get; set; }
        public ContactType ContactTypes { get; set; }
    }
}
