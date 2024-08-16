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
        public Guid CityID { get; set; }
        public Guid CountryID { get; set; }
        public Guid ProvinceID { get; set; }
        public Guid CoordinateID { get; set; }

        // Navigation Properties
        //public Street Street { get; set; }
        //public City City { get; set; }
        //public Country Country { get; set; }
        //public Province Province { get; set; }
        //public Coordinates Coordinates { get; set; }
    }
}
