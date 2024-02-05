using AutoMapper;
using CarRental.Application.CarRental.Commands.CreateNewCar;
using CarRental.Application.CarRental.Commands.EditCar;
using CarRental.Application.CarRental.Queries.GetAllCars;
using CarRental.Application.CarRental.Queries.GetCArbyId;

using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.MVC.Controllers
{
    public class CarRentalController(IMapper mapper, IMediator mediator) : Controller
    {
        public async Task <IActionResult> Index()
        {
            var cars = await mediator.Send(new GetAllCarsQuery());
            return View(cars);
        }
        public async Task<IActionResult> Create()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateNewCarCommand command)
        {
            if (!ModelState.IsValid)

            { return View(command); }

            await mediator.Send(command);

            return RedirectToAction(nameof(Index));

        }
        [Route("Car/{Id}/Details")]
        public async Task<IActionResult> Details(int id)
        {
            var cars = await mediator.Send(new GetCarByIdQuery(id));
            return View(cars);
        }


        [Route("Car/{Id}/Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var cars = await mediator.Send(new GetCarByIdQuery(id));

            EditCarCommand model = mapper.Map<EditCarCommand>(cars);
            return View(model);
        }
        [HttpPost]
        [Route("Car/{Id}/Edit")]
        public async Task<IActionResult> Edit(EditCarCommand command)
        {
            if (!ModelState.IsValid)

            { return View(command); }

            await mediator.Send(command);

            return RedirectToAction(nameof(Index));

        }


        
      
    }
}
