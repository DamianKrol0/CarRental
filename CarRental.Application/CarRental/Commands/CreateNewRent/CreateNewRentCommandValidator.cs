using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace CarRental.Application.CarRental.Commands.CreateNewRent
{
    public class CreateNewRentCommandValidator : AbstractValidator<CreateNewRentCommand>

    {
        public CreateNewRentCommandValidator()
        {
            RuleFor(c => c.StartDate).NotEmpty();
            RuleFor(c => c.EndDate).NotEmpty();
            RuleFor(c => c.CarId).NotEmpty();
            RuleFor(c => c.CreatedById).NotEmpty();
        }
    }
}
