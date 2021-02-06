using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public List<Color> GetAll()
        {        
            return _colorDal.GetAll();
        }

        
        public Color GetById(int Id)
        {
            return _colorDal.Get(c => c.Id == Id);
        }
        public bool Add(Color color)
        {
            if (color.Name.Length >= 2)
            {
                _colorDal.Add(color);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Delete(Color color)
        {
            _colorDal.Delete(color);
        }
        public bool Update(Color color)
        {
            if (color.Name.Length >= 2)
            {
                _colorDal.Update(color);
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}
