using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Credential : BaseCrudEntity<Guid>
    {
        public Guid ID { get; set; }  // Clave primaria
        public Guid UserID { get; set; }  // Clave foránea que referencia a User(ID)
        public string PasswordHash { get; set; }  // Hash de la contraseña del usuario
        public Guid RoleID { get; set; }  // Clave foránea que referencia a Role(ID)

        // Navigation properties
        //public User User { get; set; }
        //public Role Role { get; set; }
    }
}
