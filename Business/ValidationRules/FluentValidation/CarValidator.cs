using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {           
            RuleFor(c => c.Description).NotEmpty().WithMessage(Messages.CarNameInvalid);
            RuleFor(c => c.Description).MinimumLength(2).WithMessage(Messages.CarNameInvalid);
            RuleFor(c => c.DailyPrice).NotEmpty().WithMessage(Messages.CarDailyPriceInvalid);
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(0).WithMessage(Messages.CarDailyPriceInvalid); 
        }
    }
}
