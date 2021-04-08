using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CreditCardValidator : AbstractValidator<CreditCard>
    {
        public CreditCardValidator()
        {
            RuleFor(c => c.CreditCardName).NotEmpty().WithMessage(Messages.CreditCardNameInvalid);
            RuleFor(c => c.CreditCardName).MinimumLength(2).WithMessage(Messages.CreditCardNameInvalid);
            RuleFor(c => c.CardNumber).NotEmpty().WithMessage(Messages.CreditCardNameInvalid);
            RuleFor(c => c.CardNumber).MinimumLength(2).WithMessage(Messages.CreditCardNameInvalid);

        }
    }
}
