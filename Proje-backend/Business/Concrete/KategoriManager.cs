using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class KategoriManager : IKategoriService
    {
        IKategoriDal _kategoriDal;

        public KategoriManager(IKategoriDal kategoriDal)
        {
            _kategoriDal = kategoriDal;
        }

        //iş kodları
        public IDataResult<List<Kategori>> GetAll()
        {
            return new SuccessDataResult<List<Kategori>>(_kategoriDal.GetAll(),Messages.KategoriListed);
        }

        public IDataResult<Kategori> GetById(int kategoriId)
        {
           return new SuccessDataResult<Kategori>( _kategoriDal.Get(c=>c.KategoriId == kategoriId));
        }
    }
}
