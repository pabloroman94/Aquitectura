using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserFavorite : BaseCrudEntity<Guid>
    {
        public Guid UserID { get; set; }  // Clave foránea que referencia al usuario que tiene la lista de favoritos
        public Guid FavoriteUserID { get; set; }  // Clave foránea que referencia al usuario favorito

        // Navigation properties
        //public User User { get; set; }
        //public User FavoriteUser { get; set; }
    }
}
