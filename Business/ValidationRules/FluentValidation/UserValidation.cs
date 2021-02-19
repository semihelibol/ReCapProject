﻿using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().WithMessage(Messages.UserFirstNameInvalid);
            RuleFor(u => u.FirstName).MinimumLength(2).WithMessage(Messages.UserFirstNameInvalid);
            RuleFor(u => u.Mail).NotEmpty().WithMessage(Messages.UserMailInvalid);
            RuleFor(u => u.Mail).EmailAddress().WithMessage(Messages.UserMailInvalid);
            RuleFor(u => u.Password).NotEmpty().WithMessage(Messages.UserPasswordInvalid);
            RuleFor(u => u.Password).Length(6,16).WithMessage(Messages.UserPasswordInvalid);
        }
    }
}