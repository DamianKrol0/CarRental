using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Domain.Interfaces;
using MediatR;

namespace CarRental.Application.CarRental.Commands.EditCar
{
    public class EditCarCommandHandler(ICarRepository repository) : IRequestHandler<EditCarCommand>
    {
        private readonly ICarRepository _repository = repository;

        public async Task Handle(EditCarCommand request, CancellationToken cancellationToken)
        {
            var car =await _repository.GetCarById(request.Id);

            car.Name = request.Name;
            car.Brand = request.Brand;  
            car.Description = request.Description;
            car.Price = request.Price;
            car.BoxCapacity = request.BoxCapacity;  
            car.Consumption = request.Consumption;
            car.Persons = request.Persons;

            await _repository.Commit();
        }
    }
}
