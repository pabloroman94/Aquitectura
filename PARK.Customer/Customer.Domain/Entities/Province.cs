using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Province : BaseCrudEntity<Guid>
    {
        public string ProvinceName { get; set; }
        public Guid CountryID { get; set; }

        // Navigation Property
        //public Country Country { get; set; }

        // A province can have multiple cities
        //public IEnumerable<City> Cities { get; set; }
    }
}
