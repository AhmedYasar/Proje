using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfKullaniciDal : EfEntityRepositoryBase<Kullanici, Proje1Context>, IKullaniciDal
    {
        public List<MetotRol> GetClaims(Kullanici user)
        {
            using (var context = new Proje1Context())
            {
                var result = from operationClaim in context.MetotRoller
                             join userOperationClaim in context.KullaniciMetotRoller
                                 on operationClaim.MetotRolId equals userOperationClaim.KullaniciMetotRolId
                             where userOperationClaim.KullaniciId == user.KullaniciId
                             select new MetotRol { MetotRolId = operationClaim.MetotRolId, MetotRolAdi = operationClaim.MetotRolAdi };
                return result.ToList();

            }
        }
    }
}
