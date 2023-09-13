using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Photo : BaseCrudEntity<Guid>
    {
        public Customer Customer { get; set; }
        public Guid? CustomerId { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
