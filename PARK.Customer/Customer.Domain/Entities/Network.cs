using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Network : BaseCrudEntity<Guid>
    {
        public Guid UserID { get; set; }  // Clave foránea que referencia a User(ID)
        public string Description { get; set; }  // Descripción del enlace (e.g., "Facebook", "Instagram")
        public string URL { get; set; }  // URL del perfil o enlace
        public string PhoneNumber { get; set; }  // Propiedad para números de teléfono o celular
        public Guid NetworkTypeID { get; set; }  // Clave foránea que referencia a NetworkType(ID)

        // Navigation properties
        public User User { get; set; }
        public NetworkType NetworkType { get; set; }
    }
}
