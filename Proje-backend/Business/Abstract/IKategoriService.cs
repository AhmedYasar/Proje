using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IKategoriService
    {

        IDataResult<List<Kategori>> GetAll();
        IDataResult<Kategori> GetById(int kategoriId);

    }
}
