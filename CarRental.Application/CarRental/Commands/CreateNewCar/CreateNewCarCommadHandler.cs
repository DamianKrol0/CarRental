using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarRental.Application.ApplicationUser;
using CarRental.Domain.Interfaces;
using MediatR;

namespace CarRental.Application.CarRental.Commands.CreateNewCar
{
    public class CreateNewCarCommadHandler(ICarRepository carRepository, IMapper mapper,IUserContext userContext) : IRequestHandler<CreateNewCarCommand>
    {
        private readonly ICarRepository carRepository = carRepository;
        private readonly IMapper mapper = mapper;
        private readonly IUserContext userContext = userContext;

        public async Task Handle(CreateNewCarCommand request, CancellationToken cancellationToken)
        {
            var car = mapper.Map<Domain.Entities.Cars>(request);

            car.CreatedById = userContext.GetCurrentUser().id;
            await carRepository.Create(car);
          
        }
    }
}
