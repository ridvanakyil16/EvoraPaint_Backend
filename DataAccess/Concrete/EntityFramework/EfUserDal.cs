using Core.DataAccsess.EntityFramework;
using DataAccess.Abstract;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Entites.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ReCapProjectContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using(ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from op in context.OperationClaims
                             join uop in context.UserOperationClaims
                             on op.Id equals uop.OperationClaimId
                             where uop.UserId == user.Id
                             select new OperationClaim { Id = op.Id, Name = op.Name };
                return result.ToList();                   
            }
        }
    }
}
