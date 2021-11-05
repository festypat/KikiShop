using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using FluentValidation;
using KikiShop.ApplicationCore.Merchants.Command;

namespace KikiShop.ApplicationCore.Merchants.Command
{

    public class RegisterMerchantCommand : Command<Guid>
    {
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string PasswordConfirm { get; protected set; }
        public string Name { get; protected set; }

        public RegisterMerchantCommand(string email, string name, string password, string passwordConfirm)
        {
            Name = name;
            Email = email;
            Password = password;
            PasswordConfirm = passwordConfirm;
        }

        public override ValidationResult Validate()
        {
            return new RegisterMerchantCommandValidator().Validate(this);
        }
    }

    public class RegisterMerchantCommandValidator : AbstractValidator<RegisterMerchantCommand>
    {
        public RegisterMerchantCommandValidator()
        {
            RuleFor(c => c.Email)
            .NotEmpty().WithMessage("Email is empty.")
            .Length(5, 100).WithMessage("The Email must have between 5 and 100 characters.");

            RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Name is empty.")
            .Length(2, 100).WithMessage("The Name must have between 2 and 100 characters.");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is empty.");
            RuleFor(x => x.PasswordConfirm).NotEmpty().WithMessage("PasswordConfirm is empty.");
        }
    }
}
