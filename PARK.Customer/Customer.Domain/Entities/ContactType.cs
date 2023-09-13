using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ContactType : BaseCrudEntity<Guid>
    {
        public IEnumerable<Address> CustomerAddres { get; set; }
        public IEnumerable<Mail> CustomerMails { get; set; }
        public IEnumerable<Phone> CustomerPhones { get; set; }
        public string Description { get; set; }
    }
}
