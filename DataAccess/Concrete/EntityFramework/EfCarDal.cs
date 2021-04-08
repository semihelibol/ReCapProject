
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {            
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in filter is null 
                             ? context.Cars 
                             : context.Cars.Where(filter)
                             join br in context.Brands
                             on c.BrandId equals br.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 BrandId = br.Id,
                                 ColorId = co.Id,
                                 BrandName = br.Name,
                                 CarName = c.Description,
                                 ColorName = co.Name,
                                 ModelYear=c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 MinFindeksScore=c.MinFindeksScore,
                                 CarImagePath= (from ci in context.CarImages where ci.CarId == c.Id select ci.ImagePath).FirstOrDefault()==null 
                                 ? "logo.png" : (from ci in context.CarImages where ci.CarId == c.Id select ci.ImagePath).FirstOrDefault()                                 
                             };

                return result.ToList();
            }
        }
    }
}
