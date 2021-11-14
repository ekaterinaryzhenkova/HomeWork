using FluentValidation;
using WebService1.Entity1_2.Models;

namespace WebService1.Entity1_2.Validators
{
    public class HouseholdValidator : AbstractValidator<HouseholdGoods>
    {
        public HouseholdValidator()
        {
            RuleFor(x => x)
                .NotNull()
                .WithMessage("Data can not be null");

            RuleFor(x => x.Id)
                .GreaterThan(0)
                .LessThan(int.MaxValue);

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .LessThan(100000);
        }
    }
}
