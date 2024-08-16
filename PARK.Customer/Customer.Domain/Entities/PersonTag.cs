using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PersonTag : BaseCrudEntity<Guid>
    {
        public Guid PersonID { get; set; }
        public Guid TagID { get; set; }

        // Navigation properties
        //public Person Person { get; set; }
        //public Tag Tag { get; set; }
    }
}
