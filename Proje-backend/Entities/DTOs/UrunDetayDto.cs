
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UrunDetayDto:IDto
    {
        public int UrunId { get; set; }

        public string UrunAdi { get; set; }
        public string KategoriAdi { get; set; }
        public int UrunStok { get; set; }
    }
}
