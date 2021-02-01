using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new IMCarDal());
            Console.WriteLine("---Tüm Araçlar---");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Id: "+car.Id+" | MarkaId: "+car.BrandId+" | RenkId: "+car.ColorId+" | Model Yılı: "+car.ModelYear
                    +" | Günlük Kira Ücreti: "+car.DailyPrice+" | Açıklaması: "+car.Description);
            }
            Console.WriteLine("----------------------");
            Console.WriteLine("---GetById(3)---");
            Car selectedCar = carManager.GetById(3);
            Console.WriteLine("Id: "+selectedCar.Id+" | MarkaId: "+selectedCar.BrandId+" | RenkId: "+selectedCar.ColorId 
                +" | Model Yılı: "+selectedCar.ModelYear+" | Günlük Kira Ücreti: "+selectedCar.DailyPrice+" | Açıklaması: "+selectedCar.Description);
            Console.WriteLine("----------------------");
            Console.WriteLine("---Yeni Araba Ekleme---");
            carManager.Add(new Car { Id=6,BrandId=3,ColorId=2,ModelYear=2011,DailyPrice=135,Description="1.0lt Benzin"});
            Console.WriteLine("Yeni araba eklendi: "+carManager.GetById(6).Description);
            Console.WriteLine("----------------------");
            Console.WriteLine("---Araba Güncelleme---");
            selectedCar.BrandId = 2;
            selectedCar.ColorId = 2;
            selectedCar.Description = "1.3lt LPG";
            carManager.Update(selectedCar);
            Console.WriteLine("Seçilen 3 Id numaralı araç güncellendi.");
            Console.WriteLine("Id: " + selectedCar.Id + " | MarkaId: " + selectedCar.BrandId + " | RenkId: " + selectedCar.ColorId
                + " | Model Yılı: " + selectedCar.ModelYear + " | Günlük Kira Ücreti: " + selectedCar.DailyPrice + " | Açıklaması: " + selectedCar.Description);
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

            Console.WriteLine("---BrandId yerine Marka adını, ColorId yerine Renk Adını yaz---");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Id: " + car.Id 
                    + " | Marka Adı: " + carManager.GetByBrandId(car.BrandId).BrandName                    
                    + " | Renk : " + carManager.GetByColorId(car.ColorId).ColorName 
                    + " | Model Yılı: " + car.ModelYear
                    + " | Günlük Kira Ücreti: " + car.DailyPrice + " | Açıklaması: " + car.Description);
            }
            Console.WriteLine("----------------------");

        }
    }
}
