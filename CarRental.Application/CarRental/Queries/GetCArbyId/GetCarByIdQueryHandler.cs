using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarRental.Domain.Interfaces;
using MediatR;

namespace CarRental.Application.CarRental.Queries.GetCArbyId
{
    public class GetCarByIdQueryHandler(ICarRepository repository, IMapper mapper) : IRequestHandler<GetCarByIdQuery, CarsDto>
    {
        private readonly ICarRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<CarsDto> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            var car = await _repository.GetCarById(request.Id);
            var dto = _mapper.Map<CarsDto>(car);
            return dto;
        }
    }
}
