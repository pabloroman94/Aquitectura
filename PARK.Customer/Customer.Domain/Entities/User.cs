using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseCrudEntity<Guid>
    {
        public string LoginName { get; set; }
        public string ProfileDescription { get; set; }
    }
}
