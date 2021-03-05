using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Filing;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        ICarService _carService;
        string imagePath= @"..\WebAPI\Images\";        
        string[] imageExtensions ={".jpg", ".jpeg", ".png",".bmp" }; 
      
        public CarImageManager(ICarImageDal carImageDal, ICarService carService)
        {            
            _carImageDal = carImageDal;
            _carService = carService;
        }


        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage,IFormFile file)
        {
            carImage.ImagePath = imagePath+FileHelper.GenerateGUIDFileName(file, 20);
            carImage.Date = DateTime.Now;            

            IResult result = BusinessRules.Run(CheckIfCarExists(carImage.CarId),CheckIfImagesLimitExceded(carImage.CarId),
                FileHelper.CheckFileType(file, imageExtensions),FileHelper.Add(carImage.ImagePath, file));
            if (result == null)
            {
                _carImageDal.Add(carImage);
                return new SuccessResult(Messages.CarImageAdded);
            }
            return result;            
        }

        public IResult Delete(CarImage carImage)
        {
            string deletePath =_carImageDal.Get(ci => ci.Id == carImage.Id).ImagePath;

            IResult result = BusinessRules.Run(CheckIfCarImageExists(carImage.Id),FileHelper.Delete(deletePath));
            if (result == null)
            {
                _carImageDal.Delete(carImage); 
                return new SuccessResult(Messages.CarImageDeleted);
            }
            return result;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(CarImage carImage,IFormFile file)
        {
            string deletePath=_carImageDal.Get(ci => ci.Id == carImage.Id).ImagePath;
            carImage.ImagePath = imagePath+FileHelper.GenerateGUIDFileName(file, 20);
            carImage.Date = DateTime.Now;

            IResult result = BusinessRules.Run(CheckIfCarExists(carImage.CarId), CheckIfImagesLimitExceded(carImage.CarId),
                FileHelper.CheckFileType(file, imageExtensions), FileHelper.Delete(deletePath), FileHelper.Add(carImage.ImagePath, file));
            if (result == null)
            {
                _carImageDal.Update(carImage);
                return new SuccessResult(Messages.CarImageUpdated);
            }
            return result;
        }

        public IDataResult<List<CarImage>> GetAll()
        {            
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImagesListed);
        }

        public IDataResult<CarImage> GetById(int id)
        {            
            return new SuccessDataResult<CarImage>(_carImageDal.Get(ci => ci.Id == id));
        }

        public IDataResult<List<CarImage>> GetCarImagesByCarId(int carId)
        {
            IResult result = BusinessRules.Run(CheckIfCarExists(carId));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(result.Message);
            }

            IDataResult<List<CarImage>> resultData = CheckIfCarImageNull(carId);
            if (resultData.Success)
            {
                return resultData;
            }            
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(ci => ci.CarId == carId), Messages.CarImagesListed);
        }
        public IDataResult<List<CarImage>> CheckIfCarImageNull(int carId)
        {
            string logoPath = imagePath + "logo.jpg";
            var result = _carImageDal.GetAll(ci => ci.CarId == carId).Any();
            if (result==false)
            {
                List<CarImage> imageList = new List<CarImage>();
                imageList.Add(new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = logoPath });
                return new SuccessDataResult<List<CarImage>>(imageList);
            }
            return new ErrorDataResult<List<CarImage>>();
        }

        private IResult CheckIfCarExists(int carId)
        {
            var result = _carService.GetById(carId);
            if (result.Data==null)
            {
                return new ErrorResult(Messages.CarInvalid);
            }
            return new SuccessResult();
        }

        private IResult CheckIfImagesLimitExceded(int carId)
        {
            var result = _carImageDal.GetAll(ci=>ci.Id==carId);
            if (result.Count > 5)
            {
                return new ErrorResult(Messages.CarImagesLimitExceded);
            }            
            return new SuccessResult();
        }

        private IResult CheckIfCarImageExists(int id)
        {
            var result = _carImageDal.GetAll(ci => ci.Id == id).Any();
            if (!result)
            {
                return new ErrorResult(Messages.CarImageInvalid);
            }
            return new SuccessResult();
        }
        
    }
}
