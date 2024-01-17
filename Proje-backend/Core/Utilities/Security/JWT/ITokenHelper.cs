using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        //Rol değişebilir.Veritabanı değişirse rol,kullanıcı ve kullanıcı rol de değişiklik yapılacak.
        AccessToken CreateToken(Kullanici kullanıcı, List<MetotRol> rol);


    }
}
