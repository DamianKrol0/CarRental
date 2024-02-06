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
    public class RentRepository : IRentRepository
    {
        private readonly CarRentalDbContext _dbContext;

        public RentRepository(CarRentalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Commit()
        {
           await _dbContext.SaveChangesAsync();
        }

        public async Task Create(Rents rents)
        {
            _dbContext.Add(rents);  
            await _dbContext.SaveChangesAsync();    
        }

        public async Task<IEnumerable<Rents>> GetAll()
        {
           return await _dbContext.Rents.ToListAsync();
        }

        public async Task<Rents> GetRentById(int id)
        {
            return await _dbContext.Rents.FirstAsync(c=>c.Id == id);
        }
    }
}
