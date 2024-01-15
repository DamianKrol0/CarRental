using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Domain.Interfaces;
using CarRental.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Infrastructure.Repositories
{
    public class CarRepository: ICarRepository

    {
        private readonly CarRentalDbContext dbContext;

        public CarRepository(CarRentalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Domain.Entities.Cars>> GetAll()
           => await dbContext.Cars.ToListAsync();
    }
}
