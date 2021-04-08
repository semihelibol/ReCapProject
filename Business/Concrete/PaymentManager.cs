using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        IPaymentDal _paymentDal;
      

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }


        public IResult PayByCreditCard(PayByCreditCardDto payByCreditCardDto)
        {
            
            CreditCard creditCard = payByCreditCardDto.CreditCard;
            Payment payment = new Payment();
            payment.CustomerId = payByCreditCardDto.CustomerId;
            if(payByCreditCardDto.CreditCard.Id>0)
            { 
             payment.CreditCardId = payByCreditCardDto.CreditCard.Id;
                }
            payment.PaymentAmount = payByCreditCardDto.PaymentAmount;
            payment.PaymentDate = payByCreditCardDto.PaymentDate;

            IResult result = BusinessRules.Run(CheckIfCreditCard(creditCard));
            if (result == null)
            {
                _paymentDal.Add(payment);
                return new SuccessResult(Messages.PaymentAdded);
            }
            else
                return result;
        }

        public IResult CheckIfCreditCard(CreditCard creditCard)
        {            
            var result = false;
            if (creditCard.SecurityCode == "123") { result = true; }
            if (!result)
            {
                return new ErrorResult(Messages.CreditCardIsInvalid);
            }
            return new SuccessResult(Messages.CreditCardIsCorrect);
        }
    }
}
