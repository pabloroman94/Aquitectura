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

        // Navigation properties
        public Country Country { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
