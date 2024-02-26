using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Application.Currency;
using CarRental.Application.Rent;
using CarRental.Domain.Entities;

namespace CarRental.Application.Car
{
    public class CarsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Brand { get; set; } = default!;
        public string? Description { get; set; }

        public decimal Price { get; set; }

        public string? CurrencyId { get; set; }

        public decimal? Consumption { get; set; }

        public int? Persons {get; set;}
        public int BoxCapacity { get; set;}
        public string? CreatedById { get; set; }
        public bool IsEditable { get; set; }
        public  ICollection<RentDto>? Rents { get; set; }
        public CurrenciesDto? Currencies { get; set; }
   

    }
}
