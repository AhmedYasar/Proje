
using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Kategori:IEntity
    {

        [Key] public int KategoriId { get; set; }
        public string KategoriAdi { get; set; }
        public string? KategoriTanimi { get; set; }
    }
}
