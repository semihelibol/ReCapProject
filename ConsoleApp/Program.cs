
using Business.Abstract;
using Business.Concrete;
using Core.Entity;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //inMemoryTest();
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            //EfCarTest(carManager,brandManager,colorManager);
            EfBrandCRUDTest(brandManager);
            EfColorCRUDTest(colorManager);
            EfCarDetailTest(carManager);
        }

        private static void EfCarDetailTest(CarManager carManager)
        {
            Console.WriteLine("---Tüm Arabalar Detaylı---");
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("Id:{0} |  Açıklama: {1} | Marka: {2} | Renk: {3} | Günlük Kira Ücreti: {4} | "
                    , car.Id, car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
            }
            Console.WriteLine("----------------------");

            Console.WriteLine("---(Brand_Id=1) Markası Ford olan Arabalar Detaylı---");            
            List<CarDetailDto> carList = carManager.GetCarDetails();
            foreach (var car in carList.Where(b => b.BrandId == 1))
            {
                Console.WriteLine("Id:{0} |  Açıklama: {1} | Marka: {2} | Renk: {3} | Günlük Kira Ücreti: {4} | "
                    , car.Id,car.CarName,car.BrandName,car.ColorName,car.DailyPrice);
            }
            Console.WriteLine("----------------------");

            Console.WriteLine("---(Color_Id=2) Rengi Sarı olan Arabalar Detaylı---");            
            foreach (var car in carList.Where(c => c.ColorId == 2))
            {
                Console.WriteLine("Id:{0} |  Açıklama: {1} | Marka: {2} | Renk: {3} | Günlük Kira Ücreti: {4} | "
                    , car.Id, car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
            }
            Console.WriteLine("----------------------");
        }

        private static void EfColorCRUDTest(ColorManager colorManager)
        {
            Console.WriteLine("---Yeni Renk Ekleme---");
            int _id = (colorManager.Add(new Color { Name = "Turuncu" }));
            if (_id > 0)
            {
                Console.WriteLine("Yeni renk eklendi: " + colorManager.GetById(_id).Name);
            }
            else
            {
                Console.WriteLine(" Hata Oluştu!!!\n Adı alanı en az 2 karakter olmalıdır. ");
            }
            Console.WriteLine("----------------------");

            Console.WriteLine("---Tüm Renkler---");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("Id:{0} | Adı:{1} ", color.Id, color.Name);
            }
            Console.WriteLine("----------------------");
            Console.WriteLine("---GetById(2)--- (Id=2) olan marka----- ");
            Color selectedColor = colorManager.GetById(2);
            Console.WriteLine("Id:{0} | Adı:{1} ", selectedColor.Id, selectedColor.Name);
            Console.WriteLine("----------------------");

            Console.WriteLine("---Renk Güncelleme---");
            selectedColor.Name = "Sarı";
            if (colorManager.Update(selectedColor))
            {
                Console.WriteLine("Id:{0} | Adı:{1} ", selectedColor.Id, selectedColor.Name);
                Console.WriteLine("Güncellendi..");
            }
            else
            {
                Console.WriteLine(" Hata Oluştu!!!\n Adı alanı en az 2 karakter olmalıdır.");
            }
            Console.WriteLine("----------------------");

            Console.WriteLine("---Renk Silme---");
            colorManager.Delete(colorManager.GetById(_id));
            Console.WriteLine("Seçilen {0} Id numaralı renk silindi.", _id);
            Console.WriteLine("----------------------");

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("Id:{0} | Adı:{1} ", color.Id, color.Name);
            }
            Console.WriteLine("----------------------");
        }

        private static void EfBrandCRUDTest(BrandManager brandManager)
        {
            Console.WriteLine("---Yeni Marka Ekleme---");
            int _id = (brandManager.Add(new Brand {Name = "Citroen" }));
            if (_id > 0)
            {
                Console.WriteLine("Yeni marka eklendi: " + brandManager.GetById(_id).Name);
            }
            else
            {
                Console.WriteLine(" Hata Oluştu!!!\n Adı alanı en az 2 karakter olmalıdır. ");
            }
            Console.WriteLine("----------------------");

            Console.WriteLine("---Tüm Markalar---");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("Id:{0} | Adı:{1} ",brand.Id,brand.Name);
            }
            Console.WriteLine("----------------------");
            Console.WriteLine("---GetById(2)--- (Id=2) olan marka----- ");
            Brand selectedBrand = brandManager.GetById(2);
            Console.WriteLine("Id:{0} | Adı:{1} ", selectedBrand.Id, selectedBrand.Name);
            Console.WriteLine("----------------------");

            Console.WriteLine("---Marka Güncelleme---");
            selectedBrand.Name="Fiat";            
            if (brandManager.Update(selectedBrand))
            {
                Console.WriteLine("Id:{0} | Adı:{1} ", selectedBrand.Id, selectedBrand.Name);
                Console.WriteLine("Güncellendi..");
            }
            else
            {
                Console.WriteLine(" Hata Oluştu!!!\n Adı alanı en az 2 karakter olmalıdır.");
            }
            Console.WriteLine("----------------------");

            Console.WriteLine("---Marka Silme---");
            brandManager.Delete(brandManager.GetById(_id));
            Console.WriteLine("Seçilen {0} Id numaralı marka silindi.",_id);
            Console.WriteLine("----------------------");

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("Id:{0} | Adı:{1} ", brand.Id, brand.Name);
            }
            Console.WriteLine("----------------------");
        }

        private static void EfCarTest(CarManager carManager,BrandManager brandManager,ColorManager colorManager)
        {
            Console.WriteLine("---Yeni Araba Ekleme---");
            int _id = (carManager.Add(new Car { BrandId = 3, ColorId = 2, ModelYear = 2011, DailyPrice = 120, Description = "Linea" }));
            if (_id > 0)
            {
                Console.WriteLine("Yeni araba eklendi: " + carManager.GetById(_id).Description);
            }
            else
            {
                Console.WriteLine(" Hata Oluştu!!!\n Açıklama alanı en az 2 karakter olmalıdır. \n Günlük kira ücreti 0TL'den büyük olmalıdır. ");
            }
            Console.WriteLine("----------------------");
            Console.WriteLine("---Tüm Araçlar---");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"Id:{car.Id} | Marka:{brandManager.GetById(car.BrandId).Name} | Renk:{colorManager.GetById(car.ColorId).Name} | " +
                    $"Model Yılı: {car.ModelYear} | Günlük Kira Ücreti: {car.DailyPrice} TL | Açıklaması:{car.Description}");
            }
            Console.WriteLine("----------------------");

            Console.WriteLine("---GetById(2)--- (Id=2) olan araba----- ");
            Car selectedCar = carManager.GetById(2);
            Console.WriteLine($"Id:{selectedCar.Id} | Marka:{brandManager.GetById(selectedCar.BrandId).Name} | Renk:{colorManager.GetById(selectedCar.ColorId).Name} | " +
                    $"Model Yılı: {selectedCar.ModelYear} | Günlük Kira Ücreti: {selectedCar.DailyPrice} TL | Açıklaması:{selectedCar.Description}");
            Console.WriteLine("----------------------");

            Console.WriteLine("---Araba Güncelleme---");
            selectedCar.BrandId = 2;
            selectedCar.ColorId = 2;
            selectedCar.Description = "Clio";
            selectedCar.DailyPrice = 0;
            if (carManager.Update(selectedCar))
            {
                Console.WriteLine($"Id:{selectedCar.Id} | Marka:{brandManager.GetById(selectedCar.BrandId).Name} | Renk:{colorManager.GetById(selectedCar.ColorId).Name} | " +
                    $"Model Yılı: {selectedCar.ModelYear} | Günlük Kira Ücreti: {selectedCar.DailyPrice} TL | Açıklaması:{selectedCar.Description}");
            }
            else
            {
                Console.WriteLine(" Hata Oluştu!!!\n Açıklama alanı en az 2 karakter olmalıdır. \n Günlük kira ücreti 0TL'den büyük olmalıdır. ");
            }
            Console.WriteLine("----------------------");

            Console.WriteLine("---Araba Silme---");
            carManager.Delete(carManager.GetById(_id));
            Console.WriteLine($"Seçilen {_id} Id numaralı araç silindi.");
            Console.WriteLine("----------------------");

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"Id:{car.Id} | Marka:{brandManager.GetById(car.BrandId).Name} | Renk:{colorManager.GetById(car.ColorId).Name} | " +
                    $"Model Yılı: {car.ModelYear} | Günlük Kira Ücreti: {car.DailyPrice} TL | Açıklaması:{car.Description}");
            }
            Console.WriteLine("----------------------");

            Console.WriteLine($"---GetCarsByBrandId(1)---  (BrandId=3) Markası:{brandManager.GetById(1).Name} olan arabalar");
            List<Car> selectedCars = carManager.GetCarsByBrandId(1);
            foreach (var car in selectedCars)
            {
                Console.WriteLine($"Id:{car.Id} | Marka:{brandManager.GetById(car.BrandId).Name} | Renk:{colorManager.GetById(car.ColorId).Name} | " +
                                    $"Model Yılı: {car.ModelYear} | Günlük Kira Ücreti: {car.DailyPrice} TL | Açıklaması:{car.Description}");
            }
            Console.WriteLine("----------------------");

            Console.WriteLine($"---GetCarsByColorId(2)---  (ColorId=2) Rengi:{colorManager.GetById(2).Name} olan arabalar");
            selectedCars = carManager.GetCarsByColorId(2);
            foreach (var car in selectedCars)
            {
                Console.WriteLine($"Id:{car.Id} | Marka:{brandManager.GetById(car.BrandId).Name} | Renk:{colorManager.GetById(car.ColorId).Name} | " +
                                    $"Model Yılı: {car.ModelYear} | Günlük Kira Ücreti: {car.DailyPrice} TL | Açıklaması:{car.Description}");
            }
        }

        static void inMemoryTest() 
        {
            CarManager carManager = new CarManager(new IMCarDal());
            Console.WriteLine("---Tüm Araçlar---");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Id: " + car.Id + " | MarkaId: " + car.BrandId + " | RenkId: " + car.ColorId + " | Model Yılı: " + car.ModelYear
                    + " | Günlük Kira Ücreti: " + car.DailyPrice + " | Açıklaması: " + car.Description);
            }
            Console.WriteLine("----------------------");
            Console.WriteLine("---GetById(3)---");
            Car selectedCar = carManager.GetById(3);
            Console.WriteLine("Id: " + selectedCar.Id + " | MarkaId: " + selectedCar.BrandId + " | RenkId: " + selectedCar.ColorId
                + " | Model Yılı: " + selectedCar.ModelYear + " | Günlük Kira Ücreti: " + selectedCar.DailyPrice + " | Açıklaması: " + selectedCar.Description);
            Console.WriteLine("----------------------");
            Console.WriteLine("---Yeni Araba Ekleme---");
            int _id = carManager.Add(new Car { Id = 6, BrandId = 3, ColorId = 2, ModelYear = 2011, DailyPrice = 120, Description = "1.0lt Benzin" });
            if (_id>0)
            {
                Console.WriteLine("Yeni araba eklendi: " + carManager.GetById(_id).Description);
            }
            else
            {
                Console.WriteLine(" Hata Oluştu!!!\n Açıklama alanı en az 2 karakter olmalıdır. \n Günlük kira ücreti 0TL'den büyük olmalıdır. ");
            }
            Console.WriteLine("----------------------");
            Console.WriteLine("---Araba Güncelleme---");
            selectedCar.BrandId = 2;
            selectedCar.ColorId = 2;
            selectedCar.Description = "1.3lt LPG";
            selectedCar.DailyPrice = 0;
            if (carManager.Update(selectedCar))
            {
                Console.WriteLine("Seçilen 3 Id numaralı araç güncellendi: " + carManager.GetById(6).Description);
                Console.WriteLine("Id: " + selectedCar.Id + " | MarkaId: " + selectedCar.BrandId + " | RenkId: " + selectedCar.ColorId
                + " | Model Yılı: " + selectedCar.ModelYear + " | Günlük Kira Ücreti: " + selectedCar.DailyPrice + " | Açıklaması: " + selectedCar.Description);
            }
            else
            {
                Console.WriteLine(" Hata Oluştu!!!\n Açıklama alanı en az 2 karakter olmalıdır. \n Günlük kira ücreti 0TL'den büyük olmalıdır. ");
            }
            Console.WriteLine("----------------------");
            Console.WriteLine("---Araba Silme---");
            carManager.Delete(selectedCar);
            Console.WriteLine("Seçilen 3 Id numaralı araç silindi.");
            Console.WriteLine("----------------------");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Id: " + car.Id + " | MarkaId: " + car.BrandId + " | RenkId: " + car.ColorId + " | Model Yılı: " + car.ModelYear
                    + " | Günlük Kira Ücreti: " + car.DailyPrice + " | Açıklaması: " + car.Description);
            }
            Console.WriteLine("----------------------");
        }
    }
}
