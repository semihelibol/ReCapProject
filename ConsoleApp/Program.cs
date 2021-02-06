
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

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

            Console.WriteLine("---Yeni Araba Ekleme---");
            int _id = (carManager.Add(new Car { BrandId = 3, ColorId = 2, ModelYear = 2011, DailyPrice = 120, Description = "Linea" }));
            if (_id>0)
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
