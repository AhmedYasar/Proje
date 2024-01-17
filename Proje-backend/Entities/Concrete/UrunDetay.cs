using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class UrunDetay:IEntity
    {
        [Key]
        public int UrunDetayId { get; set; }

        public int UrunId { get; set; }
        public string? DetayAdi { get; set; }
        public string? DetayDegeri { get; set; } 

    }
}
