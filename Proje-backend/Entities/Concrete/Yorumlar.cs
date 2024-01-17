using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Yorumlar:IEntity
    {
        [Key]
        public int YorumId { get; set; }
        public int KullaniciId { get; set; }
        public int UrunId { get; set; }
        public string Yorum { get; set; }
        public DateTime YorumTarihi { get; set; }
    }
}
