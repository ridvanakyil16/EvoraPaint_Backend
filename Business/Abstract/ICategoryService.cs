using Core.Utilities.Results;
using Entites.Concrete;

namespace Business.Abstract
{
    public interface ICategoryService : IRepsoitoryService<CategoryTranslation>
    {
        public IDataResult<List<CategoryTranslation>> GetAllById(int categoryId);
        public IDataResult<List<CategoryTranslation>> GetAllByLangId(int languageId);
    }
}
