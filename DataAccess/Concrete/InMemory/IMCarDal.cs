using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                new Brand{Id=1,Name="Ford" },
                new Brand{Id=2,Name="Opel" },
                new Brand{Id=3,Name="Fiat" }
            };

            _colors = new List<Color> 
            { 
                new Color{Id=1,Name="Red"},
                new Color{Id=2,Name="Gri"},
                new Color{Id=3,Name="Siyah"},
                new Color{Id=4,Name="Beyaz"}
            };

        }

        

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=>c.Id==car.Id);//gelen car.Id yi _cars listesinden bul ve carToDelete referansını ver.
            _cars.Remove(carToDelete);
        }

        

        

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }
        

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }



        public void Add(Car car)
        {
            _cars.Add(car);          
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
