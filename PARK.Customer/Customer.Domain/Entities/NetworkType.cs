using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class NetworkType : BaseCrudEntity<Guid>
    {
        public string Description { get; set; }  // Descripción del tipo de red social (e.g., "Social Media", "Website")
        public string IconURL { get; set; }  // Descripción del tipo de red social (e.g., "Social Media", "Website")

        // Navigation property
        //public IEnumerable<Network> Networks { get; set; }  // Una relación uno a muchos con Network
    }
}
