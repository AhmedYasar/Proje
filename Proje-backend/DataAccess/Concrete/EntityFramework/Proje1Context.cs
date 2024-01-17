using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //Context :Db tabloları ile proje claslarını bağlarız.
    public class Proje1Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //gerçek bir projede server= den sonra bir ip adresi girilir
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-15VP3RQ;Database=Proje1;Trusted_Connection=true");
        }
        //Dbset içindeki nesnemi veritabanındaki tablo ile ilişkilendir.
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
       public DbSet<KargoFirma> kargoFirmalari { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<MetotRol> MetotRoller { get; set; }
        public DbSet<KullaniciMetotRol> KullaniciMetotRoller { get; set; }
        public DbSet<SatisKargoBilgisi> SatisKargoBilgisi { get; set; }
        public DbSet<Satis> Satislar { get; set; }
        public DbSet<Sepet> Sepet { get; set; }
        public DbSet<Uretici> Ureticiler { get; set; }
        public DbSet<UrunDetay> UrunDetaylar { get; set; }
        public DbSet<Yorumlar> Yorumlar { get; set; }

    }
}
