﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Infrastructure.Persistance
{
    public class CarRentalDbContext:IdentityDbContext
    {
        public CarRentalDbContext(DbContextOptions<CarRentalDbContext> options) : base(options)
        {
            
        }
        public DbSet<Domain.Entities.Cars> Cars { get; set; }
        public DbSet<Domain.Entities.Currencies> Currencies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Domain.Entities.Cars>()
                .Property(c=>c.Consumption).HasColumnType("decimal(6,2)").HasPrecision(1);
            
            modelBuilder.Entity<Domain.Entities.Cars>()
                .Property(c => c.Price).HasColumnType("decimal(5,2)").HasPrecision(2);
            
        }
    }
}
