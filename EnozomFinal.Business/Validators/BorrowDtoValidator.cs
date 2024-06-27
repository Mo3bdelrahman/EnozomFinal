using EnozomFinal.Application.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnozomFinal.Application.Validators
{
    public class BorrowDtoValidator : AbstractValidator<BorrowDto>
    {
        public BorrowDtoValidator()
        {
            RuleFor(e => e.ExpectedReturnDate)
                .NotNull().WithMessage("{PropertyName} is required.")
                .NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(e => e.CopyId)
                .NotNull().WithMessage("{PropertyName} is required.")
                .NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(e => e.StudentId)
                .NotNull().WithMessage("{PropertyName} is required.")
                .NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}
