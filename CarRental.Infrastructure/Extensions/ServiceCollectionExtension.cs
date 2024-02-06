using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Domain.Interfaces;
using CarRental.Infrastructure.Persistance;
using CarRental.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarRental.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CarRentalDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("CarRental")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<CarRentalDbContext>();
                


            services.AddScoped<DbContext, CarRentalDbContext>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IRentRepository, RentRepository>();
            

        }
    }
}
