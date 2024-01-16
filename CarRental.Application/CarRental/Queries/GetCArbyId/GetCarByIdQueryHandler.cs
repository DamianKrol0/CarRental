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
    public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, CarsDto>
    {
        private readonly ICarRepository repository;
        private readonly IMapper mapper;

        public GetCarByIdQueryHandler(ICarRepository repository,IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CarsDto> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            var car = await repository.GetCarById(request.Id);
            var dto = mapper.Map<CarsDto>(car);
            return dto;
        }
    }
}
