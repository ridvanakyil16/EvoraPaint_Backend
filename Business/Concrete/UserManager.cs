using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Entites.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(User entity)
        {
                _userDal.Add(entity);
                return new SuccessResult(Messages.UserAdded);
        }

        [CacheRemoveAspect("IProductService.Get")]
        public IResult Delete(User entity)
        {
                _userDal.Delete(entity);
                return new SuccessResult(Messages.UserDeleted);
        }

        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(User entity)
        {
                _userDal.Update(entity);
                return new SuccessResult(Messages.UserUpdated);
        }

        [CacheAspect]
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UsersListed);
        }
        [CacheAspect]
        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(p => p.Id == id), Messages.UserListed);
        }
        [CacheAspect]
        public IDataResult<List<OperationClaim>> ClaimsGet(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }
        [CacheAspect]
        public IDataResult<User> Email(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }
    }
}
