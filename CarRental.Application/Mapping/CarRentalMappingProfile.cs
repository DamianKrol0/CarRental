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
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;


namespace CarRental.Application.Mapping
{
    public class CarRentalMappingProfile : Profile
    {
        public CarRentalMappingProfile(IUserContext usercontext,UserManager<IdentityUser> userMrg)
        {
            var user = usercontext.GetCurrentUser();
            

            CreateMap<CarsDto, Domain.Entities.Cars>().ReverseMap();
            CreateMap<CarsDto, EditCarCommand>();
            CreateMap<Domain.Entities.Rents, RentDto>().
                ForMember(dto => dto.CreatedBy, opt => opt.MapFrom(src => userMrg.FindByIdAsync(src.CreatedById).Result.UserName));


            CreateMap<Domain.Entities.Cars, CarsDto>()
                .ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => user != null && src.CreatedById == user.id));
        }
    }
}
