﻿using FluentValidation;

namespace Application.Validators
{
    public static class ValidatorExtensions
    {
        public static IRuleBuilder<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder) 
        {
            var options = ruleBuilder
                .NotEmpty()
                .MinimumLength(6).WithMessage("Password must be atleast 6 characters")
                .Matches("[A-Z]").WithMessage("Password must atleast contain 1 upper case character")
                .Matches("[a-z]").WithMessage("Password must atleast contain 1 lower case character")
                .Matches("[0-9]").WithMessage("Password must contain a number")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain non-alphanumeric");

            return options;
        }
        
    }
}
