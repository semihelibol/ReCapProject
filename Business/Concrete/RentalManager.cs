using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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
            return new SuccesDataResult<List<Rental>>(_rentalDal.GetAll());
        }


        public IDataResult<Rental> GetById(int Id)
        {
            var result = new DataResult<Rental>(_rentalDal.Get(r => r.Id == Id));
            if (result.Data == null) //Verilen Idli bir Kiralama Kaydı yoksa
            {
                return new ErrorDataResult<Rental>(result.Data, Messages.RecordInvalid);
            }
            else
                return new SuccesDataResult<Rental>(result.Data);
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
    }            
}
