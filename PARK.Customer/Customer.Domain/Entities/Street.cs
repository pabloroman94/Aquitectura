using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Street : BaseCrudEntity<Guid>
    {
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string Floor { get; set; }
        public Guid CityID { get; set; }

        // Navigation properties
        public City City { get; set; }
        public ICollection<UserAddress> UserAddresses { get; set; }
    }
}
