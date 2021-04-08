using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        

        public RentalValidator()
        {
            RuleFor(r => r.CarId).NotEmpty().WithMessage(Messages.CarInvalid);
            RuleFor(r => r.CustomerId).NotEmpty().WithMessage(Messages.CustomerInvalid);
            RuleFor(r => r.RentDate).NotEmpty().WithMessage(Messages.RentalRentDateInvalid);            
        }
    }
}
