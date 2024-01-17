using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUrunService
    {
        IDataResult<List<Urun>> GetAll();
        IDataResult<List<Urun>> GetAllByCategoryId(int id);
        IDataResult<List<Urun>> GetByUnitPrice(decimal min, decimal max);
        IResult Add(Urun urun);
        IDataResult<Urun> GetById(int urunId);

        IResult Update(Urun urun);
        IDataResult<List<UrunDetayDto>> GetUrunDetay();

        IResult AddTransactionalTest (Urun urun);

    }
}
