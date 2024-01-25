using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
namespace CarRental.Application.CarRental.Commands.EditCar
{
    public class EditCarCommandValidator:AbstractValidator<EditCarCommand>
    {
        public EditCarCommandValidator() {

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
