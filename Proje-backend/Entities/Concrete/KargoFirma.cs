using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class KargoFirma : IEntity
    {
        [Key]
        public int KargoFirmaId { get; set; }
        public string FirmaAdi { get; set; }

        public string FirmaIletisim { get; set; }
    }
}
