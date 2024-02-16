using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarRental.Domain.Interfaces;
using MediatR;

namespace CarRental.Application.Rent.Queries.GetRentById
{
    public class GetRentByIdQuery(int id) : IRequest<RentDto>
    {
        public int Id { get; } = id;
    }
    public class GetRentByIdQueryHandler(IRentRepository rentRepository, IMapper mapper) : IRequestHandler<GetRentByIdQuery, RentDto>
    {
        private readonly IRentRepository _rentRepository = rentRepository;
        private readonly IMapper _mapper = mapper;
        public async Task<RentDto> Handle(GetRentByIdQuery request, CancellationToken cancellationToken)
        {
            var rent = await _rentRepository.GetRentById(request.Id);

            var dto = _mapper.Map<RentDto>(request);
            return dto;
        }
    }
}
