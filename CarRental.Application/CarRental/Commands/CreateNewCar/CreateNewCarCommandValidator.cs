using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Domain.Interfaces;
using FluentValidation;

namespace CarRental.Application.CarRental.Commands.CreateNewCar
{
    public class CreateNewCarCommandValidator : AbstractValidator<CreateNewCarCommand>
    {
        public CreateNewCarCommandValidator(ICarRepository repository)
        {
            RuleFor(c => c.Name)
                .NotEmpty();
            RuleFor(c => c.Price)
               .NotEmpty();
            RuleFor(c => c.Brand)
               .NotEmpty();
 

            RuleFor(c => c.Consumption)
               .NotEmpty();
            RuleFor(c => c.Persons)
               .NotEmpty();

        }
    }
}
