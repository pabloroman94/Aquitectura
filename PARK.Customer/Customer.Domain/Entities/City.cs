using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class City : BaseCrudEntity<Guid>
    {
        public string CityName { get; set; }
        public string PostalCode { get; set; }
        public Guid ProvinceID { get; set; }

        // Navigation properties
        public Province Province { get; set; }
        public ICollection<Street> Streets { get; set; }
    }
}
