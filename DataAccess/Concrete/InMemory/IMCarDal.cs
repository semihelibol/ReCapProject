using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class IMCarDal : ICarDal
    {
        List<Car> _cars;
        List<Brand> _brands;
        List<Color> _colors;
        public IMCarDal()
        {//İlk oluşturulduğunda bir car listemiz oluşturulsun.
            _cars = new List<Car>{ 
                new Car{Id=1,BrandId=1,ColorId=1,DailyPrice=95,ModelYear=2008,Description="1.5 lt Dizel"},
                new Car{Id=2,BrandId=2,ColorId=2,DailyPrice=145,ModelYear=2018,Description="1.2 lt Benzin"},
                new Car{Id=3,BrandId=1,ColorId=1,DailyPrice=115,ModelYear=2012,Description="1.4 lt LPG"},
                new Car{Id=4,BrandId=2,ColorId=2,DailyPrice=125,ModelYear=2010,Description="1.6 lt Dizel"},
                new Car{Id=5,BrandId=3,ColorId=3,DailyPrice=85,ModelYear=2009,Description="1.6 lt Benzin"},
            };

            _brands = new List<Brand>
            {
                new Brand{BrandId=1,BrandName="Ford" },
                new Brand{BrandId=2,BrandName="Opel" },
                new Brand{BrandId=3,BrandName="Fiat" }
            };

            _colors = new List<Color> 
            { 
                new Color{ColorId=1,ColorName="Red"},
                new Color{ColorId=2,ColorName="Gri"},
                new Color{ColorId=3,ColorName="Siyah"},
                new Color{ColorId=4,ColorName="Beyaz"}
            };

        }

        public void Add(Car car)
        {
            _cars.Add(car);

        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=>c.Id==car.Id);//gelen car.Id yi _cars listesinden bul ve carToDelete referansını ver.
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Brand GetByBrandId(int BrandId)
        {
            return _brands.SingleOrDefault(b => b.BrandId == BrandId);
        }

        public Color GetByColorId(int ColorId)
        {
            return _colors.SingleOrDefault(co => co.ColorId == ColorId);
        }

        public Car GetById(int Id)
        {
            return _cars.SingleOrDefault(c=>c.Id==Id);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
