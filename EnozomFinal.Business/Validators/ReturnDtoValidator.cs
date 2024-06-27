using EnozomFinal.Application.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnozomFinal.Application.Validators
{
    public class ReturnDtoValidator : AbstractValidator<ReturnDto>
    {
        public ReturnDtoValidator()
        {
            RuleFor(e => e.BorrowId)
                .NotNull().WithMessage("{PropertyName} is required.")
                .NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(e => e.StatusId)
                .NotNull().WithMessage("{PropertyName} is required.")
                .NotEmpty().WithMessage("{PropertyName} is required.");

        }
    }
}
