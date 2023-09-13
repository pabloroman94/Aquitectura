using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DocumentType : BaseCrudEntity<Guid>
    {
        public IEnumerable<Customer> Customers { get; set; }
        public string Description { get; set; }
        public int? CustomerType { get; set; }
    }
}