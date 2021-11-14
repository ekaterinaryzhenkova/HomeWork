using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService1.Entity3.Models;

namespace WebService1.Entity3.Validators
{
    public class BookValidator : AbstractValidator<Book>, IBookValidator
    {
        public BookValidator()
        {
            RuleFor(x => x.BookName)
                .NotNull()
                .NotEmpty()
                .Must(name => name.ToUpper() != "Name")
                .WithMessage("Incorrect data");

            RuleFor(x => x.AuthorName)
                .NotNull()
                .NotEmpty()
                .Must(name => name.ToUpper() != "Name")
                .WithMessage("Incorrect data");

            RuleFor(x => x.Id) //??
                .NotEmpty()
                .Must(x => x >= 14 && x <= 110)
                .WithMessage("Incorrect data");
        }
    }
}
