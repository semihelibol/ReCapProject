using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi.";
        public static string CarNameInvalid = "Araba adı hatalı girildi. En az 2 karakter olmalıdır.";
        public static string CarDailyPriceInvalid = "Günlük kira ücreti sıfırdan büyük olmalıdır.";
        public static string CarDeleted = "Araba silindi.";
        public static string CarUptaded = "Araba güncellendi.";
        public static string CarsListed="Arabalar listelendi.";
        public static string CarListed="Araba listelendi.";
        public static string CarInvalid="Araba bulunamadı.";
        public static string BrandsListed="Markalar listelendi.";
        public static string BrandInvalid="Marka bulanamadı.";
        public static string BrandNameInvalid = "Renk adı hatalı girildi. En az 2 karakter olmalıdır.";
        public static string BrandAdded="Marka eklendi.";
        public static string BrandDeleted="Marka silindi.";
        public static string BrandUpdated="Marka güncellendi.";
        public static string ColorAdded="Renk eklendi.";
        public static string ColorDeleted="Renk silindi.";
        public static string ColorUpdated="Renk güncellendi.";
        public static string ColorInvalid = "Renk bulanamadı.";
        public static string ColorNameInvalid= "Renk adı hatalı girildi. En az 2 karakter olmalıdır.";
        public static string UserInvalid="Kullanıcı bulunamdı.";
        public static string UserFirstNameInvalid= "İsim hatalı girildi. En az 2 karakter olmalıdır.";
        public static string UserMailInvalid="Mail hatalı girildi.";
        public static string UserPasswordInvalid = "Şifre hatalı girildi.Şifre; 6-16 karakter arasında olmalıdır.";
        public static string UserAdded="Kullanıcı eklendi.";
        public static string UserDeleted="Kullanıcı silindi.";
        public static string UserUpdated="Kullanıcı güncellendi.";
        public static string CustomerInvalid="Müşteri bulunmadı.";
        public static string CustomerAdded="Müşteri eklendi.";
        public static string CustomerUserIdInvalid = "Kullanıcı Id hatalı.";
        public static string CustomerCompanyNameInvalid = "Şirket adı hatalı girildi. En az 2 karakter olmalıdır.";
        public static string CustomerDeleted="Müşteri silindi.";
        public static string CustomerUpdated="Müşteri güncellendi.";
        public static string RecordInvalid="Kiralama kaydı bulunamdı.";
        public static string RentalAdded="Kiralama işlemi gerçekleştirildi.";
        public static string CarIsRented="Araba kiralanmış görünüyor.";
        public static string CarIsRentable="Araba kiralana bilir.";
        public static string RentalDeleted="Kiralama kaydı silindi.";
        public static string RentalUpdated="Kiralama işlemi sonlandırıldı.";
        public static string NoCarOnRent="Kirada hiç araba yok.";
        public static string CarOnRent="Araba kirada görünüyor.";
        public static string UsedInRental="Araba kiralamada kullanığı için silinemez.";
        
    }
}
