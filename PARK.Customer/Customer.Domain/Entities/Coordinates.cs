using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Coordinates : BaseCrudEntity<Guid>
    {
        public Guid UserAddressID { get; set; }
        public decimal Lng { get; set; }
        public decimal Lat { get; set; }
        public string GoogleMapsURL { get; set; }

        // Navigation Property
        //public UserAddress UserAddress { get; set; }
    }
}
