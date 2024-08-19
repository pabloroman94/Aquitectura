using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Coordinates : BaseCrudEntity<Guid>
    {
        public decimal Lng { get; set; }  // Longitud
        public decimal Lat { get; set; }  // Latitud
        public string GoogleMapsURL { get; set; }

        // Navigation properties
        public UserAddress UserAddress { get; set; }
    }
}
