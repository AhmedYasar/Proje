using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class KullaniciMetotRol:IEntity
    {
        [Key]
        public int KullaniciMetotRolId { get; set; }
        public int KullaniciId { get; set; }
        public int MetotRolId { get; set; }

    }
}
