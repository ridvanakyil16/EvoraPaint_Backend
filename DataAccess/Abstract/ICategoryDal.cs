using Core.DataAccess;
using Entites.Concrete;
using Entites.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<CategoryTranslation>
    {
        //List<CategoryDetailsDto> GetAllCategoryDetail(Expression<Func<Category, bool>> filter = null);
        //CategoryDetailsDto GetCategoryDetail(Expression<Func<Category, bool>> filter);
    }
}
