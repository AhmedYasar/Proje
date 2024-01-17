
using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Urun:IEntity
    {
        [Key] public int UrunId { get; set; }

        public string UrunAdi { get; set; }

        public string UrunTanimi  { get; set; }

        public decimal UrunFiyati { get; set; }
        public int UrunStok { get; set; }

        public string? UrunResimURL { get; set; } 
        
         public DateTime EklenmeTarihi { get; set; }

        public int KategoriId { get; set; }

        public int UreticiId { get; set; }

    }
}
