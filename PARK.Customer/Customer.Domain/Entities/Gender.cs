using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Gender : BaseCrudEntity<Guid>
    {
        public IEnumerable<Person> Persons { get; set; }
        public string Description { get; set; }
    }
}
