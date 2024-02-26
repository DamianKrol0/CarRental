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
    public class CurrenciesRepository : ICurrenciesRepository
    {
        private readonly CarRentalDbContext _dbContext;

        public CurrenciesRepository(CarRentalDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<IEnumerable<Currencies>> GetAll()
        {
          return await _dbContext.Currencies.ToListAsync();
        }
    }
}
