using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserCompany : BaseCrudEntity<Guid>
    {
        public string CompanyName { get; set; }

        // Navigation properties
        //public User User { get; set; }
        //public IEnumerable<CompanyCategory> CompanyCategories { get; set; }
        //public IEnumerable<CompanyTag> CompanyTags { get; set; }
    }
}
