using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public List<Brand> GetAll()
        {
           return _brandDal.GetAll();
        }

        public Brand GetById(int Id)
        {
            return _brandDal.Get(c => c.Id == Id);
        }
        public bool Add(Brand brand)
        {
            if (brand.Name.Length >= 2)
            {
                _brandDal.Add(brand);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
        }
        public bool Update(Brand brand)
        {
            if (brand.Name.Length >= 2)
            {
                _brandDal.Update(brand);
                return true;
            }
            else
            {
                return false;
            }
        }

        List<Brand> IBrandService.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
