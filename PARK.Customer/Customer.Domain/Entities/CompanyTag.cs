using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CompanyTag : BaseCrudEntity<Guid>
    {
        public Guid CompanyID { get; set; }
        public Guid TagID { get; set; }

        // Navigation properties
        public UserCompany Company { get; set; }
        public Tag Tag { get; set; }
    }
}
