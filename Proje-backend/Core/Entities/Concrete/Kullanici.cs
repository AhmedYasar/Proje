using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class Kullanici : IEntity
    {
        [Key]
        public int KullaniciId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public byte[] Sifre { get; set; }
        public byte[] SifreSalt { get; set; }
        public string? Telefon { get; set; }
        public string? Adres { get; set; }
        public DateTime? KayitTarihi { get; set; }
        public bool Durum { get; set; }

    }
}
