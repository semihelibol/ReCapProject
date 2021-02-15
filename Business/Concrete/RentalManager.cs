using Business.Abstract;
using Business.Constants;
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
        
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }


        public IDataResult<Rental> GetById(int Id)
        {
            var result = new DataResult<Rental>(_rentalDal.Get(r => r.Id == Id));
            if (result.Data == null) //Verilen Idli bir Kiralama Kaydı yoksa
            {
                return new ErrorDataResult<Rental>(result.Data, Messages.RecordInvalid);
            }
            else
                return new SuccessDataResult<Rental>(result.Data);
        }

        public IResult CarRentable(int carId)
        {
            var result = _rentalDal.GetRentalDetails(r => r.CarId == carId && r.ReturnDate == null);
            if (result.Count()>0)
            {
                return new ErrorResult(Messages.CarIsRented);
            }
            return new SuccessResult(Messages.CarIsRentable);
        }

        public IResult Add(Rental rental)
        {            
            var result = CarRentable(rental.CarId);
            if (result.Success)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }
            return new ErrorResult(Messages.CarIsRented);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }
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
            var result = new DataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(r => r.ReturnDate == null));
            if (result.Data.Count == 0) //Verilen Idli bir Kiralama Kaydı yoksa
            {
                return new ErrorDataResult<List<RentalDetailDto>>(Messages.NoCarOnRent);

            }
            else
                return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(r => r.ReturnDate == null), Messages.CarOnRent);          
        }
    }            
}
