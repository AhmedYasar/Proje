using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class MetotRol : IEntity
    {
        [Key]
        public int MetotRolId { get; set; }
        public string MetotRolAdi { get; set; }

    }
}
