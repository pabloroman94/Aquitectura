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
        public Guid CategoryID { get; set; }

        // Navigation properties
        public UserCategory Category { get; set; }
        public ICollection<PersonProfession> PersonProfessions { get; set; }
    }
}
