using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Cashing;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Business;
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
using System.Threading;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IColorService _colorService;
        IBrandService _brandService;

        public CarManager(ICarDal carDal, IColorService colorService, IBrandService brandService)
        {
            _carDal = carDal;
            _colorService = colorService;
            _brandService = brandService;
        }

        [CacheAspect]
        [PerformanceAspect(1)]
        [LogAspect(typeof(FileLogger))]
        public IDataResult<List<Car>> GetAll()
        {            
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            IResult result = BusinessRules.Run(CheckIfBrandExists(brandId));
            if (result != null)
            {
                return new ErrorDataResult<List<Car>>(result.Message);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId), Messages.CarsListed);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            IResult result = BusinessRules.Run(CheckIfColorExists(colorId));
            if (result != null)
            {
                return new ErrorDataResult<List<Car>>(result.Message);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId), Messages.CarsListed);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }

        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            IResult result = BusinessRules.Run(CheckIfCarExists(id));
            if (result != null)
            {
                return new ErrorDataResult<Car>(result.Message);
            }
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));

        }

        [SecuredOperation("car.add,add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        [TransactionScopeAspect]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfBrandExists(car.BrandId), CheckIfColorExists(car.ColorId));
            if (result == null)
            {
                _carDal.Add(car);
                //transaction seneryosu
                car.ColorId = 230;//230 Id numaralı bir renk olmadığı için hataya düşecek
                _carDal.Update(car);
                ////////////////////////////////
                return new SuccessResult(Messages.CarAdded);
            }
            else
                return result;
        }

        [SecuredOperation("car.delete,delete,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfCarExists(car.Id));
            if (result == null)
            {
                _carDal.Delete(car);
                return new SuccessResult(Messages.CarDeleted);
            }
            else
                return result;

        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfCarExists(car.Id), CheckIfBrandExists(car.BrandId), CheckIfColorExists(car.ColorId));
            if (result == null)
            {
                _carDal.Update(car);
                return new SuccessResult(Messages.CarUptaded);
            }
            else
                return result;
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarsListed);
        }

        private IResult CheckIfCarExists(int id)
        {
            var result = _carDal.GetAll(c => c.Id == id).Any();
            if (!result)
            {
                return new ErrorResult(Messages.CarInvalid);
            }
            return new SuccessResult();
        }

        private IResult CheckIfBrandExists(int brandId)
        {
            //var result = _brandService.GetAll().Data.Where(b=>b.Id==brandId).Any();
            var result = _brandService.GetById(brandId);
            if (result.Data == null)
            {
                return new ErrorResult(Messages.BrandInvalid);
            }
            return new SuccessResult();
        }

        private IResult CheckIfColorExists(int colorId)
        {
            var result = _colorService.GetById(colorId);
            if (result.Data == null)
            {
                return new ErrorResult(Messages.ColorInvalid);
            }
            return new SuccessResult();
        }

    }    
        
}
