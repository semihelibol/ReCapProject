using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public IDataResult<List<Color>> GetAll()
        {        
            return new SuccesDataResult<List<Color>>(_colorDal.GetAll());
        }

        
        public IDataResult<Color> GetById(int Id)
        {
            var result = new DataResult<Color>(_colorDal.Get(c => c.Id == Id));
            if (result.Data == null) //Verilen Idli bir Renk yoksa
            {
                return new ErrorDataResult<Color>(result.Data, Messages.ColorInvalid);
            }
            else
                return new SuccesDataResult<Color>(result.Data);
        }
        public IResult Add(Color color)
        {
            if (color.Name.Length < 2)
            {
                return new ErrorResult(Messages.ColorNameInvalid);
            }
            else
            {
                _colorDal.Add(color);
                return new SuccessResult(Messages.ColorAdded);
            }            
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }
        public IResult Update(Color color)
        {
            if (color.Name.Length < 2)
            {
                return new ErrorResult(Messages.ColorNameInvalid);
            }
            else
            {
                _colorDal.Update(color);
                return new SuccessResult(Messages.ColorUpdated);
            }            
        }
    }
}
