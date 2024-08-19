using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CompanyBusinessType : BaseCrudEntity<Guid>
    {
        public Guid CompanyID { get; set; }
        public Guid BusinessTypeID { get; set; }

        // Navigation properties
        public UserCompany Company { get; set; }
        public BusinessType BusinessType { get; set; }

    }
}