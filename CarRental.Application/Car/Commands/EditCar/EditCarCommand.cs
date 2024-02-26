using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Application.ApplicationUser;
using CarRental.Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace CarRental.Application.Car.Commands.EditCar
{
    public class EditCarCommand : CarsDto,IRequest
    {
    }
    public class EditCarCommandHandler(ICarRepository repository, IUserContext userContext) : IRequestHandler<EditCarCommand>
    {
        private readonly ICarRepository _repository = repository;
        private readonly IUserContext _userContext = userContext;

        public async Task Handle(EditCarCommand request, CancellationToken cancellationToken)
        {
            var user = _userContext.GetCurrentUser();


            var car = await _repository.GetCarById(request.Id);
            var isEditable = user != null && car.CreatedById == user.id;
            if (isEditable)
            {
                car.Name = request.Name;
                car.Brand = request.Brand;
                car.Description = request.Description;
                car.Price = request.Price;
                car.CurrencyId = request.CurrencyId;
                car.BoxCapacity = request.BoxCapacity;
                car.Consumption = request.Consumption;
                car.Persons = request.Persons;

                await _repository.Commit();
            }

        }
    }
    public class EditCarCommandValidator : AbstractValidator<EditCarCommand>
    {
        public EditCarCommandValidator()
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
