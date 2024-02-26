using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Application.Car;
using CarRental.Domain.Entities;

namespace CarRental.Application.Currency
{
    public class CurrenciesDto
    {
           
        
        public string CurrencyId { get; set; } = default!;
        public string Code { get; set; } = default!;
        public string Name { get; set; } = default!;
        public ICollection<CarsDto> Cars { get; set; }
    }
}
