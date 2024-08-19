using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserCompany :User// BaseCrudEntity<Guid>
    {
        public string CompanyName { get; set; }

        // Navigation properties
        public ICollection<Classification> Classifications { get; set; }
        public ICollection<CompanyTag> CompanyTags { get; set; }
        //public ICollection<CompanyBusinessType> CompanyBusinessTypes { get; set; }  // Agrega esta línea

    }
}
