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
    public class CarRepository : ICarRepository

    {
        private readonly CarRentalDbContext _dbContext;

        public CarRepository(CarRentalDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public Task Commit()
        =>_dbContext.SaveChangesAsync(); 

        public async Task Create(Cars car)
        {
            _dbContext.Add(car);
            await _dbContext.SaveChangesAsync(); 
        }

        public async Task<IEnumerable<Domain.Entities.Cars>> GetAll()
           => await _dbContext.Cars.ToListAsync();

        public async Task<Cars> GetCarById(int id)
        => await _dbContext.Cars.FirstAsync(c => c.Id == id);
    }
}
