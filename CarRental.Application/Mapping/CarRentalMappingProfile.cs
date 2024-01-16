﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarRental.Application.CarRental;

namespace CarRental.Application.Mapping
{
    public class CarRentalMappingProfile : Profile
    {
        public CarRentalMappingProfile()
        {
            CreateMap<CarsDto, Domain.Entities.Cars>().ReverseMap();
        }
    }
}