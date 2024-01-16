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
        private readonly CarRentalDbContext dbContext;

        public CarRepository(CarRentalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task Commit()
        =>dbContext.SaveChangesAsync(); 

        public async Task Create(Cars car)
        {
            dbContext.Add(car);
            await dbContext.SaveChangesAsync(); 
        }

        public async Task<IEnumerable<Domain.Entities.Cars>> GetAll()
           => await dbContext.Cars.ToListAsync();

        public async Task<Cars> GetCarById(int id)
        => await dbContext.Cars.FirstAsync(c => c.Id == id);
    }
}
