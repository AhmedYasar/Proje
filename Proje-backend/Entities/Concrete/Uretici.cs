using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Uretici:IEntity
    {
        [Key]
        public int UreticiId { get; set; }
        public string UreticiAdi { get; set; }
        public string? Ureticiİletisim { get; set; }
        public string? UreticiAdresi { get; set; }  

    }
}
