using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        
        public IDataResult<Color> GetById(int Id)
        {
            var result = new DataResult<Color>(_colorDal.Get(c => c.Id == Id));
            if (result.Data == null) //Verilen Idli bir Renk yoksa
            {
                return new ErrorDataResult<Color>(result.Data, Messages.ColorInvalid);
            }
            else
                return new SuccessDataResult<Color>(result.Data);
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);           
        }
    }
}
