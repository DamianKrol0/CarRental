using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarRental.Domain.Interfaces;
using MediatR;

namespace CarRental.Application.Rent.Command.DeleteRent
{
    public class DeleteRentCommand :RentDto ,IRequest
    {
        
    }
    public class DeleteRentCommandHandler(IMapper mapper,IRentRepository rentRepository) : IRequestHandler<DeleteRentCommand>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IRentRepository _rentRepository = rentRepository;

        public async Task Handle(DeleteRentCommand request, CancellationToken cancellationToken)
        {
            var rent =  _mapper.Map<RentDto>(request);

            await _rentRepository.Delete(rent.Id);
        }
    }
}
