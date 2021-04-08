using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator : AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(co => co.Name).NotEmpty().WithMessage(Messages.ColorNameInvalid);
            RuleFor(co => co.Name).MinimumLength(2).WithMessage(Messages.ColorNameInvalid);
        }
    }
}
