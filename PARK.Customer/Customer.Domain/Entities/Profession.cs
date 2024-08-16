using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Profession : BaseCrudEntity<Guid>
    {
        public string ProfessionName { get; set; }
        public int CategoryID { get; set; }

        // Navigation properties
        //public Category Category { get; set; }
        //public IEnumerable<PersonProfession> PersonProfessions { get; set; }
    }
}
