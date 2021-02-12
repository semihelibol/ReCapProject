﻿using Core.DataAcces;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
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
                                 DailyPrice = c.DailyPrice                                 
                             };

                return result.ToList();
            }
        }
    }
}