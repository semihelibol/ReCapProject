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
            RuleFor(c => c.DailyPrice).GreaterThan(0).WithMessage(Messages.CarDailyPriceInvalid);
            RuleFor(c => c.MinFindeksScore).GreaterThanOrEqualTo(Convert.ToInt16(0)).WithMessage(Messages.CarMinFindeksScoreInvalid);
            RuleFor(c => c.MinFindeksScore).LessThanOrEqualTo(Convert.ToInt16(1900)).WithMessage(Messages.CarMinFindeksScoreInvalid);
            RuleFor(c => c.ModelYear).GreaterThanOrEqualTo(Convert.ToInt16(1923)).WithMessage(Messages.CarModelYearInvalid);
            RuleFor(c => c.ModelYear).LessThanOrEqualTo(Convert.ToInt16(2923)).WithMessage(Messages.CarModelYearInvalid);
        }
    }
}
