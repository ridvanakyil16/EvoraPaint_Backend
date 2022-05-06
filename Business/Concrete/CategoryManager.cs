using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entites.Concrete;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {

        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        [CacheRemoveAspect("ICategoryService.Get()")]
        public IResult Add(CategoryTranslation entity)
        {
            _categoryDal.Add(entity);
            return new SuccessResult(Messages.CategoryAdded);
        }

        [CacheRemoveAspect("ICategoryService.Get()")]
        public IResult Delete(CategoryTranslation entity)
        {
            _categoryDal.Delete(entity);
            return new SuccessResult(Messages.CategoryDeleted);
        }

        [CacheRemoveAspect("ICategoryService.Get()")]
        public IResult Update(CategoryTranslation entity)
        {
            _categoryDal.Update(entity);
            return new SuccessResult(Messages.CategoryUpdated);
        }

        [CacheAspect]
        public IDataResult<List<CategoryTranslation>> GetAll()
        {
            return new SuccessDataResult<List<CategoryTranslation>>(_categoryDal.GetAll(), Messages.CategoriesListed);
        }

        [CacheAspect]
        public IDataResult<List<CategoryTranslation>> GetAllById(int categoryId)
        {
            return new SuccessDataResult<List<CategoryTranslation>>(_categoryDal.GetAll(p => p.CategoryId == categoryId), Messages.CategoriesListed);
        }

        [CacheAspect]
        public IDataResult<List<CategoryTranslation>> GetAllByLangId(int langId)
        {
            return new SuccessDataResult<List<CategoryTranslation>>(_categoryDal.GetAll(p => p.LanguageId == langId), Messages.CategoriesListed);
        }

        [CacheAspect]
        public IDataResult<CategoryTranslation> GetById(int id)
        {
            return new SuccessDataResult<CategoryTranslation>(_categoryDal.Get(p => p.Id == id), Messages.CategoryListed);
        }

        //public IDataResult<Language> GetByLang(int id, int langId)
        //{
        //    Language language = new Language();
        //    var getByCategoryId = GetById(id);
        //    if(langId == 1)
        //    {

        //            language.Id = getByCategoryId.Data.Id;
        //            language.Name = getByCategoryId.Data.TRName;

        //        return new SuccessDataResult<Language>(language, "Türkçe Kategoriler listelendi");

        //    }
        //    else
        //    {

                
        //            language.Id = getByCategoryId.Data.Id;
        //            language.Name = getByCategoryId.Data.ENName;
                
        //        return new SuccessDataResult<Language>(language, "İngilizce Kategoriler listelendi");
        //    }
        //}
    }
}
