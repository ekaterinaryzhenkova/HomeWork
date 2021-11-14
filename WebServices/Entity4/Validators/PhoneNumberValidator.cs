using FluentValidation;
using System;
using WebService1.Entity4.DbModels;

namespace WebService1.Entity4.Validators
{
    public class PhoneNumberValidator : AbstractValidator<DbPhoneNumber>, IPhoneNumberValidator
    {
        public PhoneNumberValidator()
        {
            RuleFor(x => x.Number)
                .NotNull()
                .NotEmpty()
                .Must(x => x.Length ==11)
                //проверка на циферки
                .WithMessage("Incorrect data");

            RuleFor(x => x.CustomerId)
                .NotEmpty()
                .Must(x => x > 0)
                //проверка на idCustomer?
                .WithMessage("Incorrect Id");
        }
    }
}
