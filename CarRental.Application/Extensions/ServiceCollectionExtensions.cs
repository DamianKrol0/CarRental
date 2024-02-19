using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarRental.Application.ApplicationUser;
using CarRental.Application.Car.Commands.CreateNewCar;
using CarRental.Application.Mapping;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using FluentValidation.AspNetCore;
using CarRental.Application.Rent.Command.CreateNewRent;
using Microsoft.AspNetCore.Identity;

namespace CarRental.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserContext, UserContext>();
            services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));
            services.AddScoped(provider => new MapperConfiguration(cfg =>
            {
            var scope = provider.CreateScope();
                var userContext =scope.ServiceProvider.GetRequiredService<IUserContext>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                cfg.AddProfile(new CarRentalMappingProfile(userContext, userManager));
            }).CreateMapper());

            services.AddValidatorsFromAssemblyContaining<CreateNewCarCommandValidator>()
                    .AddFluentValidationAutoValidation()
                    .AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining<CreateNewRentCommandValidator>()
                   .AddFluentValidationAutoValidation()
                   .AddFluentValidationClientsideAdapters();
        }
    }


    
}
