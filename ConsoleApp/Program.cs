﻿
//using Business.Abstract;
//using Business.Concrete;
//using Core.Entity;
//using DataAccess.Concrete.EntityFramework;
//using DataAccess.Concrete.InMemory;
//using Entities.Concrete;
//using Entities.DTOs;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace ConsoleApp
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            //CarManager carManager = new CarManager(new EfCarDal());
//            //BrandManager brandManager = new BrandManager(new EfBrandDal());
//            //ColorManager colorManager = new ColorManager(new EfColorDal());
//            //UserManager userManager = new UserManager(new EfUserDal());
//            //CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
//            //RentalManager rentalManager = new RentalManager(new EfRentalDal());
//            //EfRentalTest(userManager, customerManager, rentalManager);          
//            //EfCarTest(carManager,brandManager,colorManager);            
//            //EfCarDetailTest(carManager);

//           // NewMethod();
//        }

//        private static void NewMethod()
//        {
//            var result = rentalManager.GetRentalDetailsOnRent();
//            if (result.Success)
//            {
//                foreach (var rent in result.Data)
//                {
//                    Console.WriteLine("Id:{0} |  Araba:{1} | Ad Soyad:{2} {3} | Şirket:{4} | Kiralama tarihi: {5} | "
//                        , rent.Id, rent.CarName, rent.FirstName, rent.LastName, rent.CompanyName, rent.RentDate);
//                }
//                Console.WriteLine("Toplam {0} adet {1}", result.Data.Count, result.Message);
//            }
//            else
//                Console.WriteLine(result.Message);

//            var cars = carManager.GetCarDetails();
//            if (cars.Success)
//            {
//                foreach (var car in cars.Data)
//                {
//                    if (rentalManager.CarRentable(car.Id).Success)
//                        Console.WriteLine("Id:{0} |  Açıklama: {1} | Marka: {2} | Renk: {3} | Günlük Kira Ücreti: {4} | "
//                        , car.Id, car.CarName, car.BrandName, car.ColorName, car.DailyPrice);


//                }
//            }
//        }

//        private static void EfCarDetailTest(CarManager carManager)
//        {
//            Console.WriteLine("---Tüm Arabalar Detaylı---");
//            var result = carManager.GetCarDetails();
//            if (result.Success)
//            {
//                foreach (var car in result.Data)
//                {
//                    Console.WriteLine("Id:{0} |  Açıklama: {1} | Marka: {2} | Renk: {3} | Günlük Kira Ücreti: {4} | "
//                        , car.Id, car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
//                }
//            }
//            else
//            {
//                Console.WriteLine(result.Message);            
//            }

//            Console.WriteLine("----------------------");
            
//        }

//        static void EfRentalTest(UserManager userManager, CustomerManager customerManager, RentalManager rentalManager)
//        {
//            Console.WriteLine("---Yeni Kullanıcı Ekleme---");
//            User newUser = new User { FirstName = "Semih", LastName = "Elibol", Mail = "ss@ss.com", Password = "12345" };
//            var result = userManager.Add(newUser);
//            if (result.Success)
//            {
//                Console.WriteLine("{0}:{1} {2}", result.Message, newUser.FirstName, newUser.LastName);
//            }
//            else
//            {
//                Console.WriteLine(result.Message);
//            }
//            Console.WriteLine("----------------------");
//            Console.WriteLine("---Yeni Müşteri Ekleme---");
//            Customer newCustomer = new Customer { UserId = newUser.Id, CompanyName = "ss Ltd.Şti." };
//            result = customerManager.Add(newCustomer);
//            if (result.Success)
//            {
//                Console.WriteLine("{0}:{1}", result.Message, newCustomer.CompanyName);
//            }
//            else
//            {
//                Console.WriteLine(result.Message);
//            }
//            Console.WriteLine("----------------------");

//            Console.WriteLine("---Araç kiralama------");
//            Rental newRental = new Rental { CarId = 2, CustomerId = newUser.Id, RentDate = new DateTime(2021, 2, 11) };
//            result = rentalManager.Add(newRental);
//            if (result.Success)
//            {
//                Console.WriteLine("Musteri Id:{0} Car Id:{1}  Kiralama Tarihi:{2}  {3}", newRental.CustomerId, newRental.CarId, newRental.RentDate, result.Message);
//            }
//            else
//                Console.WriteLine(result.Message);
//            Console.WriteLine("----------------------");

//            Console.WriteLine("---Araç kiralama Sonlandırma------");
//            var selectedRental = rentalManager.GetById(newRental.Id);
//            selectedRental.Data.ReturnDate = new DateTime(2021, 2, 12);
//            result = rentalManager.Update(selectedRental.Data);
//            if (result.Success)
//            {
//                Console.WriteLine("Musteri Id:{0} Car Id:{1}  Kiralama Tarihi:{2}  Teslim Tarihi:{3} {4}"
//                    , selectedRental.Data.CustomerId, selectedRental.Data.CarId, selectedRental.Data.RentDate, selectedRental.Data.ReturnDate, result.Message);
//            }
//            else
//                Console.WriteLine(result.Message);
//            Console.WriteLine("----------------------");


//            Console.WriteLine("---Tüm Kiralamalar Detaylı---");
//            var rentalList = rentalManager.GetRentalDetails();
//            if (rentalList.Success)
//            {
//                foreach (var rent in rentalList.Data)
//                {
//                    Console.WriteLine("Id:{0} |  Araba Adı: {1} | Müşteri: {2} | Şirket: {3} | Kira Tarihi: {4}|{5} | "
//                        , rent.Id, rent.CarName, rent.FirstName + ' ' + rent.LastName, rent.CompanyName,
//                        rent.RentDate, rent.ReturnDate);
//                }
//            }
//            Console.WriteLine("----------------------");

//            Console.WriteLine("---CarId(2) Detaylı Kiralama---");
//            rentalList = rentalManager.GetRentalDetailsByCarId(2);
//            if (rentalList.Success)
//            {
//                foreach (var rent in rentalList.Data)
//                {
//                    Console.WriteLine("Id:{0} |  Araba Adı: {1} | Müşteri: {2} | Şirket: {3} | Kira Tarihi: {4}|{5} | "
//                        , rent.Id, rent.CarName, rent.FirstName + ' ' + rent.LastName, rent.CompanyName,
//                        rent.RentDate, rent.ReturnDate);
//                }
//            }
//            Console.WriteLine("----------------------");

//            Console.WriteLine("---CustomerId(2) Detaylı Kiralama---");
//            rentalList = rentalManager.GetRentalDetailsByCustomerId(2);
//            if (rentalList.Success)
//            {
//                foreach (var rent in rentalList.Data)
//                {
//                    Console.WriteLine("Id:{0} |  Araba Adı: {1} | Müşteri: {2} | Şirket: {3} | Kira Tarihi: {4}|{5} | "
//                        , rent.Id, rent.CarName, rent.FirstName + ' ' + rent.LastName, rent.CompanyName,
//                        rent.RentDate, rent.ReturnDate);
//                }
//            }
//            Console.WriteLine("----------------------");
//        }
//        private static void EfCarTest(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
//        {
//            Console.WriteLine("---Yeni Araba Ekleme---");
//            Car newCar = new Car { BrandId = 3, ColorId = 2, ModelYear = 2011, DailyPrice = 120, Description = "Linea" };
//            var result = carManager.Add(newCar);
//            if (result.Success)
//            {
//                Console.WriteLine("{0}:{1}",result.Message, newCar.Description);
//            }
//            else
//            {
//                Console.WriteLine(result.Message);
//            }
//            Console.WriteLine("----------------------");
//            Console.WriteLine("---Tüm Araçlar---");
//            var resultCarList = carManager.GetAll();
//            if (resultCarList.Success)
//            {
//                foreach (var car in resultCarList.Data)
//                {
//                    Console.WriteLine("Id:{0} | Marka:{1} | Renk:{2} | Model Yılı: {3} | Günlük Kira Ücreti: {4} TL | Açıklaması:{5}"
//                        ,car.Id, car.BrandId,car.ColorId,car.ModelYear,car.DailyPrice,car.Description);
//                }
//                Console.WriteLine(resultCarList.Message);
//            }
//            else
//            {
//                Console.WriteLine(resultCarList.Message);
//            }
//            Console.WriteLine("----------------------");

//            Console.WriteLine("---GetById(2)--- (Id=2) olan araba----- ");
//            var selectedCar = carManager.GetById(8);
//            if (selectedCar.Success)
//            {
//                Console.WriteLine("Id:{0} | Marka:{1} | Renk:{2} | Model Yılı: {3} | Günlük Kira Ücreti: {4} TL | Açıklaması:{5}"
//                        , selectedCar.Data.Id, selectedCar.Data.BrandId, selectedCar.Data.ColorId, selectedCar.Data.ModelYear,
//                        selectedCar.Data.DailyPrice, selectedCar.Data.Description);
//                Console.WriteLine(selectedCar.Message);
//            }
//            else
//            {
//                Console.WriteLine(selectedCar.Message);
//            }
//            Console.WriteLine("----------------------");

//            Console.WriteLine("---Araba Güncelleme---");
//            if (selectedCar.Success)
//            {
//                selectedCar.Data.BrandId = 2;
//                selectedCar.Data.ColorId = 2;
//                selectedCar.Data.Description = "Clio";
//                selectedCar.Data.DailyPrice = 0;
//                result = carManager.Update(selectedCar.Data);
//                if (result.Success)
//                {
//                    Console.WriteLine("{0}:{1}", result.Message, selectedCar.Data.Description);
//                }
//                else
//                {
//                    Console.WriteLine(result.Message);
//                }
//            }
//            else
//                Console.WriteLine(selectedCar.Message);
//            Console.WriteLine("----------------------");            

//            Console.WriteLine("---Araba Silme---");
//            //result=carManager.Delete(carManager.GetById(9).Data);
//            result = carManager.Delete(newCar);
//            if (result.Success)
//            {
//                Console.WriteLine("{0}:{1}",result.Message,newCar.Description);
//            }            
//            else
//                Console.WriteLine(result.Message);
//            Console.WriteLine("----------------------");

//            Console.WriteLine($"---GetCarsByBrandId(1)---  (BrandId=1) Markası:{brandManager.GetById(1).Data.Name} olan arabalar");
//            resultCarList = carManager.GetCarsByBrandId(1);
//            if (resultCarList.Success)
//            {
//                foreach (var car in resultCarList.Data)
//                {
//                    Console.WriteLine("Id:{0} | Marka:{1} | Renk:{2} | Model Yılı: {3} | Günlük Kira Ücreti: {4} TL | Açıklaması:{5}"
//                        , car.Id, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description);                  
//                }
//                Console.WriteLine(resultCarList.Message);
//            }
//            else
//                Console.WriteLine(resultCarList.Message);
//            Console.WriteLine("----------------------");

//            Console.WriteLine($"---GetCarsByColorId(2)---  (ColorId=2) Rengi:{colorManager.GetById(2).Data.Name} olan arabalar");
//            resultCarList = carManager.GetCarsByColorId(2);
//            if (resultCarList.Success)
//            {
//                foreach (var car in resultCarList.Data)
//                {
//                    Console.WriteLine("Id:{0} | Marka:{1} | Renk:{2} | Model Yılı: {3} | Günlük Kira Ücreti: {4} TL | Açıklaması:{5}"
//                        , car.Id, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description);
//                }
//                Console.WriteLine(resultCarList.Message);
//            }
//            else
//                Console.WriteLine(resultCarList.Message);
//        }

        
//    }
//}
