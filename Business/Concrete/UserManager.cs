using Business.Abstract;
using Business.Constants;
using Core.DataAcces;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

        public IDataResult<List<User>> GetAll()
        {
            return new SuccesDataResult<List<User>>(_userDal.GetAll());
        }


        public IDataResult<User> GetById(int Id)
        {
            var result = new DataResult<User>(_userDal.Get(u => u.Id == Id));
            if (result.Data == null) //Verilen Idli bir Kullanıcı yoksa
            {
                return new ErrorDataResult<User>(result.Data, Messages.UserInvalid);
            }
            else
                return new SuccesDataResult<User>(result.Data);
        }
        public IResult Add(User user)
        {
            if (user.FirstName.Length < 2)
            {
                return new ErrorResult(Messages.FirstNameInvalid);
            }
            else
            {
                _userDal.Add(user);
                return new SuccessResult(Messages.UserAdded);
            }
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }
        public IResult Update(User user)
        {
            if (user.FirstName.Length < 2)
            {
                return new ErrorResult(Messages.FirstNameInvalid);
            }
            else
            {
                _userDal.Update(user);
                return new SuccessResult(Messages.UserUpdated);
            }
        }

    }
}
