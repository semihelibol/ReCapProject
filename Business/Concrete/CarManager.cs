using Business.Abstract;
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

        public List<Car> GetAll()
        {
            //İş kodları
            //Yetkisi var mı?

            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }
               
        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }

        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max);
        }

        public Car GetById(int Id)
        {
            if (_carDal is IMCarDal) //CarDal inMemory ise
            {
                return _carDal.GetAll().SingleOrDefault(c => c.Id == Id);
            }
            else
            {
                return _carDal.Get(c => c.Id == Id);
            }
            
        }
        public int Add(Car car)
        {
            if (car.DailyPrice > 0 && car.Description.Length >= 2)
            {
                _carDal.Add(car);
                return car.Id;
            }
            else
            {
                return 0;
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }
        public bool Update(Car car)
        {
            if (car.DailyPrice > 0 && car.Description.Length >= 2)
            {
                _carDal.Update(car);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }                
    }
}
