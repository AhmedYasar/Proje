using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUrunDal : EfEntityRepositoryBase<Urun, Proje1Context>, IUrunDal
    {
        public List<UrunDetayDto> GetUrunDetay()
        {
            using (Proje1Context context = new Proje1Context() )
            {
                var result = from p in context.Urunler join c in context.Kategoriler
                             on p.KategoriId equals c.KategoriId
                             select new UrunDetayDto {UrunId = p.UrunId, UrunAdi=p.UrunAdi, KategoriAdi= c.KategoriAdi , UrunStok= p.UrunStok };

                return result.ToList();
            }
        }
    }
}
