using Business.Abstract;
using Business.Business.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entites.Concrete;
using Entites.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        IProductImageService _productImageService;

        public ProductManager(IProductDal productDal, IProductImageService productImageService)
        {
            _productDal = productDal;
            _productImageService = productImageService;
        }

        [SecuredOperation("admin,productAdd")]
        [ValidationAspect(typeof (CarValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IDataResult<Product> Add(Product entity)
        {
            _productDal.Add(entity);
            return new SuccessDataResult<Product>(entity,Messages.ProductAdded);
        }

        //public IResult ProductWithImageAdd(Product entity, IFormFile file, ProductImage productImage)
        //{
        //    Add(entity);
        //    _productImageService.Add(file, productImage);
        //    return new SuccessResult(Messages.ProductAdded);
        //}

        [CacheRemoveAspect("IProductService.Get")]
        public IResult Delete(Product entity)
        {
            _productDal.Delete(entity);
            return new SuccessResult(Messages.ProductDeleted);     
        }

        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product entity)
        {
            _productDal.Update(entity);
            return new SuccessResult(Messages.ProductUpdated);
        }


        //Gereksizler start
        [CacheAspect]
        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }
        
        [CacheAspect]
        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.Id == id), Messages.ProductListed);
        }
        //Gereksizler end


        [CacheAspect]
        public IDataResult<List<ProductDetailsDto>> GetAllProductDetail()
        {
            return new SuccessDataResult<List<ProductDetailsDto>>(_productDal.GetAllProductDetail(), Messages.ProductsListed);
        }
        [CacheAspect]
        public IDataResult<ProductDetailsDto> GetProductDetail(int productId)
        {
            return new SuccessDataResult<ProductDetailsDto>(_productDal.GetProductDetail(x => x.Id == productId), Messages.ProductListed);
        }
        [CacheAspect]
        public IDataResult<List<ProductDetailsDto>> GetProductByCategory(int categoryId,int languageId)
        {
            
            return new SuccessDataResult<List<ProductDetailsDto>>(_productDal.GetAllProductDetail(x => x.CategoryId == categoryId && x.LanguageId == languageId).OrderBy(x =>  x.CategoryId).ToList(), Messages.ProductsListed);
        }
        [CacheAspect]
        public IDataResult<List<ProductDetailsDto>> GetProductByLanguage(int languageId)
        {
            return new SuccessDataResult<List<ProductDetailsDto>>(_productDal.GetAllProductDetail(x => x.LanguageId == languageId), Messages.ProductsListed);
        }
        //[CacheAspect]
        //public IDataResult<List<ProductDetailsDto>> GetProductDetailByBrand(int brandId)
        //{
        //    return new SuccessDataResult<List<ProductDetailsDto>>(_productDal.GetAllProductDetail(x => x.BrandId == brandId), Messages.CarsListed);
        //}
        //[CacheAspect]
        //public IDataResult<List<ProductDetailsDto>> GetProductDetailByColor(int colorId)
        //{
        //    return new SuccessDataResult<List<ProductDetailsDto>>(_productDal.GetAllProductDetail(x => x.BrandId == colorId), Messages.CarsListed);
        //}
    }
}
