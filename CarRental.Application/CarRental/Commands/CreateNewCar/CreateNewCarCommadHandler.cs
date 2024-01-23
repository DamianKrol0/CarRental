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
    public class CreateNewCarCommadHandler(ICarRepository carRepository, IMapper mapper,IUserContext userContext,ICurrenicesRepository currenicesRepository) : IRequestHandler<CreateNewCarCommand>
    {
        private readonly ICarRepository _carRepository = carRepository;
        private readonly IMapper _mapper = mapper;
        private readonly IUserContext _userContext = userContext;
        private readonly ICurrenicesRepository _currenicesRepository = currenicesRepository;

        public async Task Handle(CreateNewCarCommand request, CancellationToken cancellationToken)
        {
            var car = _mapper.Map<Domain.Entities.Cars>(request);

            car.CreatedById = _userContext.GetCurrentUser()?.id;
           
            await _carRepository.Create(car);
          
        }
    }
}
