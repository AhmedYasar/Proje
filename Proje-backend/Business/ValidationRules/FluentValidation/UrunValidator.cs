using Core.Utilities.Results;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UrunValidator:AbstractValidator<Urun>
    {
        public UrunValidator()
        {

            RuleFor(u=>u.UrunAdi).MinimumLength(2);
            RuleFor(u => u.UrunAdi).NotEmpty();
            RuleFor(u => u.UrunFiyati).NotEmpty();
            RuleFor(u => u.UrunFiyati).GreaterThan(0);
            RuleFor(u => u.UrunFiyati).GreaterThanOrEqualTo(1000).When(u=>u.KategoriId==4);
            RuleFor(u => u.UrunAdi).Must(Filtre).WithMessage("Ürün adı özel karakter içermemelidir");
            RuleFor(u => u.UrunStok).GreaterThan(0);


        }

        private bool Filtre(string arg)
        {
            string[] karakter = { ",","_", ".", ";" };
            foreach (var item in karakter)
            {  if (arg.IndexOf(item) != -1)
                {
                    return false;
                }
            }
           return true;
        }
    }
}
