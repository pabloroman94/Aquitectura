using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Classification : BaseCrudEntity<Guid>
    {
        public Guid CompanyID { get; set; }
        public Guid? CategoryID { get; set; }
        public Guid? SubCategoryID { get; set; }
        //public Guid? BusinessTypeID { get; set; }

        // Navigation properties
        public UserCompany Company { get; set; }
        public UserCategory Category { get; set; }
        public SubCategory SubCategory { get; set; }
        //public BusinessType BusinessType { get; set; }
    }
}
