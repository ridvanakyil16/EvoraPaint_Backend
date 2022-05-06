using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {

        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Brand entity)
        {
                _brandDal.Add(entity);
                return new SuccessResult(Messages.BrandAdded);
        }
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Delete(Brand entity)
        {
                _brandDal.Delete(entity);
                return new SuccessResult(Messages.BrandDeleted);
        }
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Brand entity)
        {
                _brandDal.Update(entity);
                return new SuccessResult(Messages.BrandUpdated);
        }
        [CacheAspect]
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandsListed);
        }
        [CacheAspect]
        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(p => p.Id == id), Messages.BrandListed);
        }
    }
}
