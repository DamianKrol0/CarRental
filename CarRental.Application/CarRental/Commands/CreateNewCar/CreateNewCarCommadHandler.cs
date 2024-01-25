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
    public class CreateNewCarCommadHandler(ICarRepository carRepository, IMapper mapper, IUserContext userContext) : IRequestHandler<CreateNewCarCommand>
    {
        private readonly ICarRepository _carRepository = carRepository;
        private readonly IMapper _mapper = mapper;
        private readonly IUserContext _userContext = userContext;

        public async Task Handle(CreateNewCarCommand request, CancellationToken cancellationToken)
        {

            var user = _userContext.GetCurrentUser();

            if (!user.roles.Contains("Owner")&& !user.roles.Contains("Moderator"))
            { throw new Exception("You have no access"); }
            else
            { var car = _mapper.Map<Domain.Entities.Cars>(request);
                car.CreatedById = user.id;
            await _carRepository.Create(car);}
            
          
        }
    }
}
