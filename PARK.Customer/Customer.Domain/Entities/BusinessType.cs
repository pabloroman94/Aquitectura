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
        public Guid SubCategoryID { get; set; }

        // Navigation properties
        public SubCategory SubCategory { get; set; }
        public ICollection<Classification> Classifications { get; set; }
        //public ICollection<CompanyBusinessType> CompanyBusinessTypes { get; set; }

    }
}