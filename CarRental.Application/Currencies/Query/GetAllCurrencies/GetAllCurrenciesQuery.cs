using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Application.CarRental;
using MediatR;

namespace CarRental.Application.Currencies.Query.GetAllCurrencies
{
    public class GetAllCurrenciesQuery : IRequest<IEnumerable<CurrenciesDto>>
    {
    }
}
