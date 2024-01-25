using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Application.ApplicationUser;
using CarRental.Domain.Interfaces;
using MediatR;

namespace CarRental.Application.CarRental.Commands.EditCar
{
    public class EditCarCommandHandler(ICarRepository repository,IUserContext userContext) : IRequestHandler<EditCarCommand>
    {
        private readonly ICarRepository _repository = repository;
        private readonly IUserContext _userContext = userContext;

        public async Task Handle(EditCarCommand request, CancellationToken cancellationToken)
        {
            var user = _userContext.GetCurrentUser();
            
            
            var car =await _repository.GetCarById(request.Id);
            var isEditable = user != null && car.CreatedById == user.id;
            if (isEditable)
            {
                car.Name = request.Name;
                car.Brand = request.Brand;
                car.Description = request.Description;
                car.Price = request.Price;
                car.Currency = request.Currency;
                car.BoxCapacity = request.BoxCapacity;
                car.Consumption = request.Consumption;
                car.Persons = request.Persons;

                await _repository.Commit();
            }
            
        }
    }
}
