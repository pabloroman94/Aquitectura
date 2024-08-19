using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserPerson : User //:BaseCrudEntity<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }

        // Propiedades de navegación
        public ICollection<PersonProfession> PersonProfessions { get; set; }  // Relación con las profesiones de la persona
        public ICollection<PersonTag> PersonTags { get; set; }  // Relación con las etiquetas de la persona
    }
}
