using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PersonProfession : BaseCrudEntity<Guid>
    {
        public Guid PersonID { get; set; }
        public Guid ProfessionID { get; set; }

        // Navigation properties
        //public Person Person { get; set; }
        //public Profession Profession { get; set; }
    }
}
