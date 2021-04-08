using Business.Constants;
using Core.Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class AuthValidator: AbstractValidator<UserForRegisterDto>
    {
        public AuthValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().WithMessage(Messages.UserFirstNameInvalid);
            RuleFor(u => u.FirstName).MinimumLength(2).WithMessage(Messages.UserFirstNameInvalid);
            RuleFor(u => u.Email).NotEmpty().WithMessage(Messages.UserMailInvalid);
            RuleFor(u => u.Email).EmailAddress().WithMessage(Messages.UserMailInvalid);
            RuleFor(u => u.Password).NotEmpty().WithMessage(Messages.UserPasswordInvalid);
            RuleFor(u => u.Password).Length(6, 16).WithMessage(Messages.UserPasswordInvalid);
        }
    }
}
