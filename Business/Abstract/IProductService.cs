using Core.Utilities.Results;
using Entites.Concrete;
using Entites.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<Product> Add(Product entity);
        //IResult ProductWithImageAdd(Product entity, IFormFile file, ProductImage productImage);
        IResult Update(Product entity);
        IResult Delete(Product entity);
        IDataResult<List<Product>> GetAll();
        IDataResult<Product> GetById(int id);
        public IDataResult<List<ProductDetailsDto>> GetAllProductDetail();
        public IDataResult<ProductDetailsDto> GetProductDetail(int productId);
        public IDataResult<List<ProductDetailsDto>> GetProductByCategory(int categoryId,int languageId);
        public IDataResult<List<ProductDetailsDto>> GetProductByLanguage(int languageId);

        //public IDataResult<List<ProductDetailsDto>> GetProductDetailByBrand(int brandId);
        //public IDataResult<List<ProductDetailsDto>> GetProductDetailByColor(int colorId);
    }
}
