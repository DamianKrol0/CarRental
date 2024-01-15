using AutoMapper;
using CarRental.Application.CarRental.Queries.GetAllCars;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.MVC.Controllers
{
    public class CarRentalController : Controller
    {
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public CarRentalController(IMapper mapper, IMediator mediator)
        {
            this.mapper = mapper;
            this.mediator = mediator;
        }
        public async Task <IActionResult> Index()
        {
            var cars = await mediator.Send(new GetAllCarsQuery());
            return View(cars);
        }
    }
}
