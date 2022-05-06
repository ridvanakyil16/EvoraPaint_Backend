using Core.DataAccsess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMailDal : EfEntityRepositoryBase<Mail, ReCapProjectContext>, IMailDal
    {
    }
}
