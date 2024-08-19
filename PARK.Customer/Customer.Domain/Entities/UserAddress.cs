using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserAddress : BaseCrudEntity<Guid>
    {
        public Guid UserID { get; set; }
        public Guid StreetID { get; set; }
        public Guid? CoordinatesID { get; set; }

        // Navigation properties
        public User User { get; set; }
        public Street Street { get; set; }
        public Coordinates Coordinates { get; set; }
    }
}
