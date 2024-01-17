using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Aspects.Autofac.Validation;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Performance;
using DataAccess.Concrete.EntityFramework;

namespace Business.Concrete
{
    public class UrunManager : IUrunService
    {
        IUrunDal _urunDal;
        IKategoriService _kategoriService;
        public UrunManager(IUrunDal urunlerDal,IKategoriService kategoriService)
        {
            _urunDal = urunlerDal;
            _kategoriService = kategoriService;
        }
        [SecuredOperation("urun.ekle,Admin")]//product.add,admin
        [ValidationAspect(typeof(UrunValidator))]
        [CacheRemoveAspect("IUrunService.Get")]
        public IResult Add(Urun urun)
        {

            //business codes
            var result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(urun.UrunId), CheckIfProductNameExsists(urun.UrunAdi));
            if (result != null)
            {
                return result;
            }

            
            _urunDal.Add(urun);
            return new SuccessResult(Messages.UrunAdded);



        }
        [ValidationAspect(typeof(UrunValidator))]
        [CacheRemoveAspect("IUrunService.Get")]
        public IResult Update(Urun urun)
        {
            _urunDal.Update(urun);
            return new SuccessResult(Messages.SepetUpdated);
        }

        [CacheAspect]
        public IDataResult<List<Urun>> GetAll()
        {
            //iş kodları
            //if (DateTime.Now.Hour == 22)
            //{
            //    return new ErrorDataResult<List<Urun>>(Messages.MaintenanceTime);
            //}
            return new SuccessDataResult<List<Urun>>(_urunDal.GetAll(),Messages.ProductsListed);

        }

        public IDataResult<List<Urun>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Urun>> (_urunDal.GetAll(p=>p.KategoriId == id));
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Urun> GetById(int urunId)
        {
            return new SuccessDataResult<Urun> (_urunDal.Get(p=>p.UrunId==urunId), Messages.ProductsListed);
        }

        public IDataResult<List<Urun>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Urun>>( _urunDal.GetAll(p=>p.UrunFiyati>=min&&p.UrunFiyati<=max));
        }

        public IDataResult<List<UrunDetayDto>> GetUrunDetay()
        {
            return new SuccessDataResult<List<UrunDetayDto>>( _urunDal.GetUrunDetay());
        }


        private IResult CheckIfProductCountOfCategoryCorrect(int  urunId)
        {
            var result = _urunDal.GetAll(p => p.KategoriId == urunId).Count;
            if (result > 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();

        }


        public IResult CheckIfProductNameExsists(string urunAdi)
        {
            if (_urunDal.GetAll(p => p.UrunAdi == urunAdi).Any())
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Urun urun)
        {
            return null;
        }
        



    }
}
