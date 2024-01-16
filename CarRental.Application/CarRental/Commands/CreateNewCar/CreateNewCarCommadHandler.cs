using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarRental.Domain.Interfaces;
using MediatR;

namespace CarRental.Application.CarRental.Commands.CreateNewCar
{
    public class CreateNewCarCommadHandler(ICarRepository carRepository, IMapper mapper) : IRequestHandler<CreateNewCarCommand>
    {
        private readonly ICarRepository carRepository = carRepository;
        private readonly IMapper mapper = mapper;


        

        public async Task Handle(CreateNewCarCommand request, CancellationToken cancellationToken)
        {
            var car = mapper.Map<Domain.Entities.Cars>(request);

            await carRepository.Create(car);
          
        }
    }
}
