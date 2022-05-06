using Core.Utilities.Results;
using Entites.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ILanguageService
    {
        IResult Add(IFormFile file, Language languageImage);
        IResult Update(IFormFile file, Language languageImage);
        IResult Delete(Language languageImage);
        IDataResult<List<Language>> GetAll();
        IDataResult<Language> GetById(int id);
    }

}
