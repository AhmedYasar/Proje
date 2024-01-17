using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class KullaniciManager : IKullaniciService
    {
        IKullaniciDal _userDal;

        public KullaniciManager(IKullaniciDal userDal)
        {
            _userDal = userDal;
        }

        public List<MetotRol> GetClaims(Kullanici user)
        {
            return _userDal.GetClaims(user);
        }

        public void Add(Kullanici user)
        {
            _userDal.Add(user);
        }

        public Kullanici GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }
    }
}
