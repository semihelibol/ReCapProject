using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(cu => cu.UserId).NotEmpty().WithMessage(Messages.CustomerUserIdInvalid);
            RuleFor(cu => cu.CompanyName).NotEmpty().WithMessage(Messages.CustomerCompanyNameInvalid);
            RuleFor(cu => cu.CompanyName).MinimumLength(2).WithMessage(Messages.CustomerCompanyNameInvalid);
        }
    }
}
