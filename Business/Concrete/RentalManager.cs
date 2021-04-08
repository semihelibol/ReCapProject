using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager:IRentalService
    {
        IRentalDal _rentalDal;
        ICustomerService _customerService;
        ICarService _carService;

        public RentalManager(IRentalDal rentalDal,ICustomerService customerService, ICarService carService)
        {
            _rentalDal = rentalDal;
            _customerService = customerService;
            _carService = carService;
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }


        public IDataResult<Rental> GetById(int Id)
        {
            var result = new DataResult<Rental>(_rentalDal.Get(r => r.Id == Id),true);
            if (result.Data == null) //Verilen Idli bir Kiralama Kaydı yoksa
            {
                return new ErrorDataResult<Rental>(result.Data, Messages.RecordInvalid);
            }
            else
                return new SuccessDataResult<Rental>(result.Data);
        }

        public IResult CarRentable(int carId)
        {
            var result = _rentalDal.GetRentalDetails(r => r.CarId == carId && (r.ReturnDate == null));//||r.ReturnDate>DateTime.Today));
            if (result.Count()>0)
            {
                return new ErrorResult(Messages.CarIsRented);
            }
            return new SuccessResult(Messages.CarIsRentable);
        }

        public IResult CarRentableByRentDate(int carId, DateTime rentDate)
        {
            var result = _rentalDal.GetRentalDetails(r => r.CarId == carId && (r.ReturnDate == null || r.ReturnDate >= rentDate));
            if (result.Count() > 0)
            {
                return new ErrorResult(Messages.CarIsRented);
            }
            return new SuccessResult(Messages.CarIsRentable);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {         
            IResult result = BusinessRules.Run(CarRentableByRentDate(rental.CarId, rental.RentDate), 
                CheckIfRentalFindeksScore(rental.CarId, rental.CustomerId));
            if (result!=null)
            {
                return new ErrorResult(result.Message);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }
        public IDataResult<List<RentalDetailDto>> GetRentalDetailsByCarId(int carId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(r=>r.CarId==carId));
        }
        public IDataResult<List<RentalDetailDto>> GetRentalDetailsByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(r => r.CustomerId == customerId));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailsOnRent()
        {
            var result = new DataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(r => r.ReturnDate == null),true);
            if (result.Data.Count == 0) //Verilen Idli bir Kiralama Kaydı yoksa
            {
                return new ErrorDataResult<List<RentalDetailDto>>(Messages.NoCarOnRent);

            }
            else
                return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(r => r.ReturnDate == null), Messages.CarOnRent);          
        }

        private IResult CheckIfRentalExists(int id)
        {
            var result = _rentalDal.GetAll(r => r.Id == id).Any();
            if (!result)
            {
                return new ErrorResult(Messages.RentalInvalid);
            }
            return new SuccessResult();
        }

        private IResult CheckIfRentalFindeksScore(int carId,int customerId)
        {
            short customerFindeksScore = _customerService.GetCustomerFindeksScoreByCustomerId(customerId).Data;
            short carFindeksScore = _carService.GetById(carId).Data.MinFindeksScore;            
            if (customerFindeksScore<carFindeksScore)
            {
                return new ErrorResult(Messages.CustomerFindeksScoreIsNotEnough);
            }
            return new SuccessResult();
        }

    }            
}
