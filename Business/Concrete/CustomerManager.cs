using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager:ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }


        public IDataResult<Customer> GetById(int Id)
        {
            var result = new DataResult<Customer>(_customerDal.Get(cu => cu.Id == Id));
            if (result.Data == null) //Verilen Idli bir Müşteri yoksa
            {
                return new ErrorDataResult<Customer>(result.Data, Messages.CustomerInvalid);
            }
            else
                return new SuccessDataResult<Customer>(result.Data);
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer customer)
        {
             _customerDal.Update(customer);
             return new SuccessResult(Messages.CustomerUpdated);
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetails(), Messages.CustomersListed);
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetailsByUserId(int userId)
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetails(c => c.UserId == userId), Messages.CustomersListed);
        }
    }
}
