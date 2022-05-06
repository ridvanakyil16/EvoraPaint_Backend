using Core.DataAccsess.EntityFramework;
using DataAccess.Abstract;
using Entites.Concrete;
using Entites.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, ReCapProjectContext>, IProductDal
    {
        public List<ProductDetailsDto> GetAllProductDetail(Expression<Func<Product, bool>> filter = null)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from pro in filter is null ? context.Products : context.Products.Where(filter)
                             join cttrans in context.CategoryTranslations
                             on pro.CategoryId equals cttrans.CategoryId
                             join lang in context.Languages
                             on pro.LanguageId equals lang.Id 
                             where cttrans.LanguageId == lang.Id
                             select new ProductDetailsDto
                             {
                                 Id = pro.Id,
                                 Name = pro.Name,
                                 ProductImage = (from i in context.ProductImages where (pro.SameProductId == i.ProductId) select i.ImagePath).FirstOrDefault(),
                                 BrandName = pro.BrandName,
                                 ColorName = pro.ColorName,
                                 CategoryId = pro.CategoryId,
                                 Description = pro.Description,
                                 UnitPrice = pro.UnitPrice,
                                 LanguageId = pro.LanguageId,
                                 LanguageName = lang.Name,
                                 CategoryName = cttrans.Name,
                             };
                return result.ToList();
            }
        }
        public ProductDetailsDto GetProductDetail(Expression<Func<Product, bool>> filter)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from pro in filter is null ? context.Products : context.Products.Where(filter)
                             join cttrans in context.CategoryTranslations
                             on pro.CategoryId equals cttrans.CategoryId
                             join lang in context.Languages
                             on pro.LanguageId equals lang.Id
                             select new ProductDetailsDto
                             {
                                 Id = pro.Id,
                                 Name = pro.Name,
                                 ProductImage = (from i in context.ProductImages where (pro.SameProductId == i.ProductId) select i.ImagePath).FirstOrDefault(),
                                 BrandName = pro.BrandName,
                                 ColorName = pro.ColorName,
                                 CategoryId = pro.CategoryId,
                                 Description = pro.Description ,
                                 UnitPrice = pro.UnitPrice ,
                                 LanguageId = pro.LanguageId,
                                 LanguageName = lang.Name,
                                 CategoryName = cttrans.Name,
                             };
                return result.FirstOrDefault();
            }
        }

    }
}
