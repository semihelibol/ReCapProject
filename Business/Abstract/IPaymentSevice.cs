using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPaymentService
    {
        IResult CheckIfCreditCard(CreditCard creditCard);
        IResult PayByCreditCard(PayByCreditCardDto payByCreditCardDto);
    }
}
