using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Role : BaseCrudEntity<Guid>
    {
        public string Description { get; set; }  // Descripción del rol (e.g., "Admin", "User", "Manager")

        // Navigation property
        //public IEnumerable<Credential> Credentials { get; set; }  // Una relación uno a muchos con Credential
    }
}
