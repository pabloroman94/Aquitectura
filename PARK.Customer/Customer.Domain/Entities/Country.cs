using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Country : BaseCrudEntity<Guid>
    {
        public string CountryName { get; set; }

        // Navigation properties
        public ICollection<Province> Provinces { get; set; }
    }
}
