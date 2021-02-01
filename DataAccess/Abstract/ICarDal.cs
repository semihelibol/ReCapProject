using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal
    { //GetById, GetAll, Add, Update, Delete
        Car GetById(int Id);
        List<Car> GetAll();
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        Brand GetByBrandId(int BrandId);
        Color GetByColorId(int ColorId);
    }
}
