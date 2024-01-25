using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarRental.Domain.Interfaces;
using MediatR;

namespace CarRental.Application.CarRental.Queries.GetAllCars
{
    public class GetAllCarsQueryHandler(ICarRepository repository, IMapper mapper):IRequestHandler<GetAllCarsQuery,IEnumerable<CarsDto>>
    {
        private readonly ICarRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<CarsDto>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)

        {
            var cars = await repository.GetAll();
            var dtos = mapper.Map<IEnumerable<CarsDto>>(cars);
            return dtos;
        }

    }
}
