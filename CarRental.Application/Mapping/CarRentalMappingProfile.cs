using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarRental.Application.ApplicationUser;
using CarRental.Application.Car ;
using CarRental.Application.Car.Commands.EditCar;
using CarRental.Application.Rent;


namespace CarRental.Application.Mapping
{
    public class CarRentalMappingProfile : Profile
    {
        public CarRentalMappingProfile(IUserContext usercontext)
        {
            var user = usercontext.GetCurrentUser();

            CreateMap<CarsDto, Domain.Entities.Cars>().ReverseMap();
            CreateMap<CarsDto, EditCarCommand>();
            CreateMap<RentDto, Domain.Entities.Rents>().ReverseMap(); 


            CreateMap<Domain.Entities.Cars, CarsDto>()
                .ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => user != null && src.CreatedById == user.id));
        }
    }
}
