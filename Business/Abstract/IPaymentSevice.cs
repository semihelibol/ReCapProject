using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPaymentService
    {
        IResult CreditCardControl(CreditCard creditCard);
        IResult PayByCreditCard(CreditCard creditCard);
    }
}
