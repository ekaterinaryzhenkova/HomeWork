using FluentValidation;
using WebService1.Entity4.DbModels;

namespace WebService1.Entity4.Validators
{
    public class CustomerValidator : AbstractValidator<DbCustomer>, ICustomerValidator
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .Must(name => name.ToUpper() != "Name")
                .WithMessage("Incorrect data");

            RuleFor(x => x.Age)
                .Must(x => x >= 14 && x <= 110)
                .WithMessage("Incorrect data");
        }
    }
}
