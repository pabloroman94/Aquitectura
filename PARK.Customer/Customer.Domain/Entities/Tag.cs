using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Tag : BaseCrudEntity<Guid>
    {
        public string TagName { get; set; }

        // Navigation properties
        //public IEnumerable<PersonTag> PersonTags { get; set; }
        //public IEnumerable<CompanyTag> CompanyTags { get; set; }
    }
}
