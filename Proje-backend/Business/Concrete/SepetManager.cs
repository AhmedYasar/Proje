using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SepetManager : ISepetService
    {
        ISepetDal _sepetDal;

        public SepetManager(ISepetDal sepet)
        {
            _sepetDal = sepet;
        }
        public IResult Add(Sepet sepet)
        {
            
                _sepetDal.Add(sepet);
               return new SuccessResult(Messages.SepetAdded);
           
            
            
        }

        public IResult Delete(Sepet sepet)
        {
            _sepetDal.Delete(sepet);
            return new SuccessResult(Messages.SepetDeleted);
        }

        public IDataResult<Sepet> GetById(int sepetId)
        {
            return new SuccessDataResult<Sepet>(_sepetDal.Get(p => p.SepetId == sepetId), Messages.SepetListed);
        }

        public IResult Odeme(Sepet urun)
        {
            throw new NotImplementedException();
        }



        public bool CheckIfProductNameExsists(int urunId)
        {
            if (_sepetDal.GetAll(p => p.UrunId == urunId).Any())
            {
                return true;
            }
            return false;
        }

       public  IDataResult<List<Sepet>> GetByUserId(int userId)
        {
            return new SuccessDataResult <List<Sepet>> (_sepetDal.GetAll(p => p.KullaniciId == userId) ,Messages.SepetListed);
          

        }
        public IResult Update(Sepet sepet)
        {
            _sepetDal.Update(sepet);
            return new SuccessResult(Messages.SepetUpdated);
        }


    }
}
