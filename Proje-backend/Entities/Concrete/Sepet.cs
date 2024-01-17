using Core.Entities;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Sepet:IEntity
    {
        [Key]
        public int SepetId { get; set; }
        public int KullaniciId { get; set; }
        public int UrunId { get; set; }
        public int Adet { get; set; }
        public decimal ToplamFiyat { get; set; }

    }
}
