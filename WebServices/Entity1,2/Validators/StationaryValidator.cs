using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService1.Entity1_2.Models;

namespace WebService1.Entity1_2.Validators
{
    public class StationaryValidator : AbstractValidator<Stationary>
    {
        public StationaryValidator()
        {
            RuleFor(x => x)
                    .NotNull()
                    .WithMessage("Data can not be null");

            RuleFor(x => x.Id)
                    .GreaterThan(0)
                    .LessThan(int.MaxValue)
                    .WithMessage("Incorrect data");

            RuleFor(x => x.Name)
                    .NotNull()
                    .NotEmpty()
                    .MaximumLength(50)
                    .WithMessage("Incorrect name");

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .LessThan(100000)
                .WithMessage("Incorrect data");
        }
    }
}
