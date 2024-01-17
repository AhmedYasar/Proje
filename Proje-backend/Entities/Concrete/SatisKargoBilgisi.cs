using Core.Entities;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class SatisKargoBilgisi:IEntity
    {
        [Key]
        public int SatisId { get; set; }
        public int KargoFirmaId { get; set; }
        public string TakipNumarasi { get; set; }
        public DateTime GönderimTarihi { get; set; }
    }
}
