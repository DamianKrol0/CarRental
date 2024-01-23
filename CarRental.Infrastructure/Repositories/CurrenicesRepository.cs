using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using CarRental.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Infrastructure.Repositories
{
    public class CurrenicesRepository : ICurrenicesRepository
    {
        private readonly CarRentalDbContext _carRentalDbContext;

        public CurrenicesRepository(CarRentalDbContext carRentalDbContext)
        {
            _carRentalDbContext = carRentalDbContext;
        }

        public async Task<IEnumerable<Currencies>> GetAllCurrenices() => await _carRentalDbContext.Currencies.ToListAsync();
    }
}
