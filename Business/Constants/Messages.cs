﻿using Core.Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
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
        public static string UserInvalid="Kullanıcı bulunamadı.";
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
        public static string CustomersListed = "Müşteriler listelendi.";
        public static string RecordInvalid="Kiralama kaydı bulunamdı.";
        public static string RentalAdded="Kiralama işlemi gerçekleştirildi.";
        public static string CarIsRented="Araba kiralanmış görünüyor.";
        public static string CarIsRentable="Araba kiralana bilir.";
        public static string RentalDeleted="Kiralama kaydı silindi.";
        public static string RentalUpdated="Kiralama işlemi sonlandırıldı.";
        public static string NoCarOnRent="Kirada hiç araba yok.";
        public static string CarOnRent="Araba kirada görünüyor.";
        public static string UsedInRental="Araba kiralamada kullanığı için silinemez.";
        public static string ImageInvalid="Resim bulunamadı.";
        public static string CarImageAdded="Resim eklendi.";
        public static string CarImagesListed="Araba resimleri listelendi.";
        public static string CarImagesLimitExceded= "Resim limiti aşıldığı için yeni resim eklenemiyor.";
        public static string CarImageInvalid="Araba resmi bulunamadı.";
        public static string CarImageDeleted="Araba resmi silindi.";
        public static string ImageFileTypeInvalid="Resim formatı uyumsuz.";
        public static string CarImageSaved="Resim kaydedildi.";
        public static string CarImageUpdated="Resim güncellendi.";
        public static string AuthorizationDenied="Yetkiniz yok.";
        public static string UserRegistered="Kulanıcı kayıt oldu.";
        public static string UserSuccesfulLogin="Başarılı giriş.";
        public static string UserAlreadyExists="Kullanıcı mevcut";
        public static string AccessTokenCreated="Giriş yapıldı.";
        public static string CreditCardIsInvalid="Kredi kartı hatalı.";
        public static string CreditCardIsCorrect="Kredi kartı doğrulandı.";
        public static string NoPaidByCreditCard="Kredi kartıyla ödeme yapılamadı.";
        public static string PaidByCreditCard="Kredi kartıyla ödeme yapıldı.";
        public static string UserOrPasswordInvalid="Mail ya da şifre hatalı.";
        public static string CustomerFindeksScoreInvalid="Findeks puanı bulunamadı.";
        public static string CustomerGetFindeksScore="Findeks puanı başarıyla çekildi.";
        public static string RentalInvalid="Kiralama bulunamadı.";
        public static string RentalRentDateInvalid= "Kiralama tarihi boş geçilemez.";
        public static string CustomerFindeksScoreIsNotEnough= "Müşteri findeks puanı yeterli değil.";
        public static string CarMinFindeksScoreInvalid="Findek puanı 0-1900 arasında olmalıdır.";
        public static string CarModelYearInvalid="Geçerli bir model yılı giriniz.";
        public static string PaymentAdded="Ödeme Yapıldı.";
        public static string CreditCardAdded="Kredi Kartı eklendi.";
        public static string CreditCardDeleted="Kredi Kartı silindi.";
        public static string CreditCardUpdated="Kredi Kartı güncellendi.";
        public static string CreditCardsListed="Kredi Kartları listelendi.";
        public static string CreditCardNameInvalid = "Kredi kartının adı hatalı girildi. En az 2 karakter olmalıdır.";
    }
}
