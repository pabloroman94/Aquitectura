using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BusinessType : BaseCrudEntity<Guid>
    {
        public string TypeName { get; set; }
        public Guid CategoryID { get; set; }

        // Navigation properties
        //public CategoryModel Category { get; set; }
        //public ICollection<CompanyBusinessTypeModel> CompanyBusinessTypes { get; set; }
    }
}