using Core.Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class PayByCreditCardDto : IDto
    {
        public int? Id { get; set; }
        public int CustomerId { get; set; }
        public CreditCard CreditCard { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal PaymentAmount { get; set; }
    }
}
