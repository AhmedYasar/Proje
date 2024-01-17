using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IKullaniciService
    {
        List<MetotRol> GetClaims(Kullanici user);
        void Add(Kullanici user);
        Kullanici GetByMail(string email);
    }
}
