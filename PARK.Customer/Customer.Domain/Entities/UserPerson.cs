using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserPerson : BaseCrudEntity<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public int? ProfessionalTypeID { get; set; }  // Optional, consider removing if not in use

        // Navigation properties
        //public User User { get; set; }
        //public IEnumerable<PersonProfession> PersonProfessions { get; set; }
        //public IEnumerable<PersonTag> PersonTags { get; set; }
    }
}
