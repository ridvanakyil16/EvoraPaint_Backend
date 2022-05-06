using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entites.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductImageManager : IProductImageService
    {
        IProductImageDal _productImageDal;
        public ProductImageManager(IProductImageDal productImageDal)
        {
            _productImageDal = productImageDal;
        }

        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(IFormFile file, ProductImage productImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(productImage.ProductId));
            if (result != null)
            {
                return result;
            }
            var result2 = FileHelper.Add(file);
            if (!result2.Success)
            {
                return new ErrorResult(result2.Message);
            }
            var deneme = productImage.ImagePath;
            productImage.ImagePath = result2.Message;
            productImage.Date = DateTime.Now;
            _productImageDal.Add(productImage);
            return new SuccessResult(Messages.ImageAdded);
        }

        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(IFormFile file, ProductImage productImage)
        {
            var isImage = _productImageDal.Get(c => c.Id == productImage.Id);
            if (isImage == null)
            {
                return new ErrorResult("Image not found");
            }

            var updatedFile = FileHelper.Update(file, isImage.ImagePath);
            if (!updatedFile.Success)
            {
                return new ErrorResult(updatedFile.Message);
            }
            productImage.ImagePath = updatedFile.Message;
            productImage.Date = DateTime.Now;
            _productImageDal.Update(productImage);
            return new SuccessResult(Messages.ImageUpdated);
        }

        [CacheRemoveAspect("IProductService.Get")]
        public IResult Delete(ProductImage productImage)
        {
            FileHelper.Delete(productImage.ImagePath);
            _productImageDal.Delete(productImage);
            return new SuccessResult(Messages.ImageDeleted);
        }

        [CacheAspect]
        public IDataResult<ProductImage> Get(int productImageId)
        {
            return new SuccessDataResult<ProductImage>(_productImageDal.Get(p => p.Id == productImageId));
        }
        [CacheAspect]
        public IDataResult<List<ProductImage>> GetAll()
        {

            return new SuccessDataResult<List<ProductImage>>(_productImageDal.GetAll());
        }

        [CacheAspect]
        private IResult CheckImageLimitExceeded(int productid)
        {
            //1 arabanın en fazla 5 resmi olabilir dediğimiz kod bloğu.
            var productImageCount = _productImageDal.GetAll(p => p.ProductId == productid).Count;
            if (productImageCount >= 4)
            {
                return new ErrorResult(Messages.ImageLimitExceded);
            }

            return new SuccessResult();
        }

        [CacheAspect]
        private List<ProductImage> CheckIfCarImageNull(int id)
        {
            //Arabanın resmi yoksa default resim koyulması için yazdığımzı kod bloğu.
            string path = @"\Uploads\Images\Default.png";
            var result = _productImageDal.GetAll(c => c.ProductId == id).Any();
            if (!result)
            {
                return new List<ProductImage> { new ProductImage { ProductId = id, ImagePath = path, Date = DateTime.Now } };
            }
            return _productImageDal.GetAll(p => p.ProductId == id);
        }

        [CacheAspect]
        public IDataResult<List<ProductImage>> GetImagesByProductId(int id)
        {
            return new SuccessDataResult<List<ProductImage>>(CheckIfCarImageNull(id));
        }
    }
}
