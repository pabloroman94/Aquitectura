using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SubCategory : BaseCrudEntity<Guid>
    {
        public string SubCategoryName { get; set; }
        public Guid CategoryID { get; set; }

        // Navigation properties
        public UserCategory Category { get; set; }
        public ICollection<BusinessType> BusinessTypes { get; set; }
    }
}
