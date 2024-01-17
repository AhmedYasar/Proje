using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string UrunAdded = "Ürün eklendi";
        
        public static string UrunNameInvalid = "Ürün ismi geçersiz";
        
        public static string MaintenanceTime="Sistem bakımda" ;
        
        public static string ProductsListed = "Ürünler listelendi";

        public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir";

        public static string ProductNameAlreadyExists = "Bu isimde zaten başka bir ürün var";
        internal static string AuthorizationDenied="yetkiniz yok";

        public static string SuccessfulLogin = "Giriş yapıldı";
        public static string UserRegistered="Kullanıcı kayıt edildi";
        public static string UserNotFound="Kullanıcı bulunamadı";
        public static string PasswordError="Hatalı şifre";
        public static string UserAlreadyExists="Kullanıcı mevcut değil";
        public static string AccessTokenCreated="Token oluşturuldu";
        public static string UrunCountOfCategoryError="Ürün sınırı aşıldı";
        public static string KategoriListed = "Kategoriler listelendi";
        internal static string SepetAdded="Sepetinize eklendi";
        internal static string SepetListed="Sepetiniz listelendi";
        internal static string SepetDeleted="Sepetinizden silindi";
        internal static string SepetUpdated="Sepetiniz güncellendi";
    }
}
