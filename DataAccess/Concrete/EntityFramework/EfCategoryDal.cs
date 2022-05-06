using Core.DataAccsess.EntityFramework;
using DataAccess.Abstract;
using Entites.Concrete;
using Entites.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<CategoryTranslation, ReCapProjectContext>, ICategoryDal
    {
        // public List<CategoryDetailsDto> GetAllCategoryDetail(Expression<Func<Category, bool>> filter = null)
        //{
        //    using (ReCapProjectContext context = new ReCapProjectContext())
        //    {
        //        var result = from cat in filter is null ? context.Categories : context.Categories.Where(filter)
        //                     join cttrans in context.CategoryTranslations
        //                     on cat.Id equals cttrans.CategoryId
        //                     select new CategoryDetailsDto
        //                     {

        //                     }

        //    }
        //}
    }
}
