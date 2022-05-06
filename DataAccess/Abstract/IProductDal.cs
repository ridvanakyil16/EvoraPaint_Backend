using Core.DataAccess;
using Entites.Concrete;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
       List<ProductDetailsDto> GetAllProductDetail(Expression<Func<Product, bool>> filter = null);
       ProductDetailsDto GetProductDetail(Expression<Func<Product, bool>> filter);
    }
}
