using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserPhoto : BaseCrudEntity<Guid>
    {
        public Guid UserID { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        //public virtual User User { get; set; }
    }
}
