using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Domain.Entities;

namespace CarRental.Application.Currencies
{
    public class CurrenciesDto
    {
        public string Id { get; set; }
        public string[] Countries { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Number { get; set; }
        public int Digits { get; set; }
        public ICollection<Cars> Cars { get; set; }
    }
}
