﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarRental.Application.ApplicationUser;
using CarRental.Application.Mapping;
using Microsoft.Extensions.DependencyInjection;

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
            cfg.AddProfile(new CarRentalMappingProfile(userContext));
            }).CreateMapper());
        }
    }


    
}