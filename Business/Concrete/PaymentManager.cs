using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        public IResult CreditCardControl(CreditCard creditCard)
        {
            //var result = creditCard.SecurityCode[0] > 8 ? false : true;
            var result = false;
            if (creditCard.SecurityCode == "123") { result = true; }
            if (!result)
            {
                return new ErrorResult(Messages.CreditCardIsInvalid);
            }
            return new SuccessResult(Messages.CreditCardIsCorrect);
        }

        public IResult PayByCreditCard(CreditCard creditCard)
        {
            var result = false;
            if (creditCard.SecurityCode == "123") { result = true; }
            if (!result)
            {
                return new ErrorResult(Messages.NoPaidByCreditCard);
            }
            return new SuccessResult(Messages.PaidByCreditCard);
        }
    }
}
