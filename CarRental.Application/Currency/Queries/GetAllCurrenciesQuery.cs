using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarRental.Application.Car;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using MediatR;

namespace CarRental.Application.Currency.Queries
{
    public class GetAllCurrenciesQuery:IRequest<IEnumerable<CurrenciesDto>>
    {
    }
    public class GetAllCurrenciesQueryHandler(ICurrenciesRepository currenciesRepository,IMapper mapper) : IRequestHandler<GetAllCurrenciesQuery, IEnumerable<CurrenciesDto>>
    {
        private readonly ICurrenciesRepository _currenciesRepository = currenciesRepository;
        private readonly IMapper _mapper = mapper;

     

      
        public async Task<IEnumerable<CurrenciesDto>> Handle(GetAllCurrenciesQuery request, CancellationToken cancellationToken)
        {
            
           var currencies = await _currenciesRepository.GetAll();
           var dtos = _mapper.Map<IEnumerable<CurrenciesDto>>(currencies);
            return dtos;
        }
    }
}
