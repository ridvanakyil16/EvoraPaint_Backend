using Core.DataAccsess.EntityFramework;
using DataAccess.Abstract;
using Entites.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfLanguageDal : EfEntityRepositoryBase<Language, ReCapProjectContext>, ILanguageDal
    {
    }

}
