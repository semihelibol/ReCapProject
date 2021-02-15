using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IDataResult<List<Car>> GetAll()
        {
            //İş kodları
            //Yetkisi var mı?

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId), Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId), Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }

        public IDataResult<Car> GetById(int Id)
        {
            var result = new DataResult<Car>(_carDal.Get(c => c.Id == Id));
            if (result.Data == null) //Verilen Idli bir Araba yoksa
            {
                return new ErrorDataResult<Car>(result.Data, Messages.CarInvalid);
            }
            else
                return new SuccessDataResult<Car>(result.Data);
        }

        public IResult Add(Car car)
        {
            if (car.DailyPrice <= 0)
            {
                return new ErrorResult(Messages.CarDailyPriceInvalid);
            }
            else if (car.Description.Length < 2)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            else
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            }
        }
                
        public IResult Delete(Car car)
        {
            if (car != null)
            {
                _carDal.Delete(car);
                return new SuccessResult(Messages.CarDeleted);
            }
            else
                return new ErrorResult(Messages.CarInvalid);
        }
        
        public IResult Update(Car car)
        {
            if (car != null)
            {
                if (car.DailyPrice < 0)
                {
                    return new ErrorResult(Messages.CarDailyPriceInvalid);
                }
                else if (car.Description.Length < 2)
                {
                    return new ErrorResult(Messages.CarNameInvalid);
                }
                else
                {
                    _carDal.Update(car);
                    return new SuccessResult(Messages.CarUptaded);
                }
            }
            else
                return new ErrorResult(Messages.CarInvalid);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),Messages.CarsListed);
        }       
        
    }
}
