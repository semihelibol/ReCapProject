using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        List<Brand> GetAll();
        Brand GetById(int id);
        int Add(Brand brand);
        bool Update(Brand brand);
        void Delete(Brand brand);
       
    }
}
