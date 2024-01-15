using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Infrastructure.Persistance
{
    public class CarRentalDbContext:DbContext
    {
        public CarRentalDbContext(DbContextOptions<CarRentalDbContext> options) : base(options)
        {
            
        }
        public DbSet<Domain.Entities.Cars> Cars { get; set; }
    }
}
