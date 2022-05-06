using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entites.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class LanguageManager : ILanguageService
    {

        ILanguageDal _languageDal;

        public LanguageManager(ILanguageDal languageDal)
        {
            _languageDal = languageDal;
        }

        [CacheRemoveAspect("ILanguageService.Get")]
        public IResult Add(IFormFile file, Language languageImage)
        {
            var result = FileHelper.Add(file);
            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }
            var deneme = languageImage.ImagePath;
            languageImage.ImagePath = result.Message;
            _languageDal.Add(languageImage);
            return new SuccessResult(Messages.LangAdded);
        }

        [CacheRemoveAspect("ILanguageService.Get")]
        public IResult Update(IFormFile file, Language languageImage)
        {
            var updatedFile = FileHelper.Update(file, languageImage.ImagePath);
            if (!updatedFile.Success)
            {
                return new ErrorResult(updatedFile.Message);
            }
            languageImage.ImagePath = updatedFile.Message;
            _languageDal.Update(languageImage);
            return new SuccessResult(Messages.LangUpdated);
        }

        [CacheRemoveAspect("ILanguageService.Get")]
        public IResult Delete(Language languageImage)
        {
            FileHelper.Delete(languageImage.ImagePath);
            _languageDal.Delete(languageImage);
            return new SuccessResult(Messages.LangDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Language>> GetAll()
        {
            return new SuccessDataResult<List<Language>>(_languageDal.GetAll(), Messages.LangsListed);
        }
        [CacheAspect]
        public IDataResult<Language> GetById(int id)
        {
            return new SuccessDataResult<Language>(_languageDal.Get(p => p.Id == id), Messages.LangListed);
        }
    }
}
