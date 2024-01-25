using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarRental.Domain.Interfaces;
using MediatR;

namespace CarRental.Application.Currencies.Query.GetAllCurrencies
{
    public class GetAllCurrenciesQueryHandler : IRequestHandler<GetAllCurrenciesQuery, IEnumerable<CurrenciesDto>>
    {
        private readonly ICurrenicesRepository _currenicesRepository;
        private readonly IMapper _mapper;

        public GetAllCurrenciesQueryHandler(ICurrenicesRepository currenicesRepository, IMapper mapper)
        {
            _currenicesRepository = currenicesRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CurrenciesDto>> Handle(GetAllCurrenciesQuery request, CancellationToken cancellationToken)
        {
            var currencies = await _currenicesRepository.GetAllCurrenices();

            var dtos = _mapper.Map<IEnumerable<CurrenciesDto>>(currencies);

             return  dtos;
        }
    }
}
