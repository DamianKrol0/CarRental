using AutoMapper;
using CarRental.Application.Car.Commands.CreateNewCar;
using CarRental.Application.Car.Commands.EditCar;
using CarRental.Application.Car.Queries.GetAllCars;
using CarRental.Application.Car.Queries.GetCArbyId;
using CarRental.Application.Currency;
using CarRental.Application.Currency.Queries;
using CarRental.Application.Rent.Command.CreateNewRent;
using CarRental.Domain.Entities;
using CarRental.MVC.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarRental.MVC.Controllers
{
    public class CarRentalController(IMapper mapper, IMediator mediator) : Controller
    {
        public async Task <IActionResult> Index()
        {
            var cars = await mediator.Send(new GetAllCarsQuery());
            var currencies = await mediator.Send(new GetAllCurrenciesQuery());
            foreach (var car in cars)
            {
                car.Currencies = ((from c in currencies
                                  where c.CurrencyId == car.CurrencyId
                                  select c).FirstOrDefault() as CurrenciesDto);
            }
            return View(cars);
        }
        public async Task<IActionResult> Create()
        {
            var currencies =await  mediator.Send(new GetAllCurrenciesQuery());
            ViewBag.Currencies = new SelectList(currencies,"CurrencyId","Code");

             return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateNewCarCommand command)
        {
            if (!ModelState.IsValid)

            { return View(command); }

            await mediator.Send(command);

            this.SetNotification("success", $"Created car: {command.Name}");

            return RedirectToAction(nameof(Index));

        }
        [Route("Car/{Id}/Details")]
        public async Task<IActionResult> Details(int id)
        {
            var cars = await mediator.Send(new GetCarByIdQuery(id));
            return View(cars);
        }


        [Route("Car/{Id}/Edit")]
        [Authorize(Roles = "Owner")]
        [Authorize(Roles = "Moderator")]
        public async Task<IActionResult> Edit(int id)
        {
            var cars = await mediator.Send(new GetCarByIdQuery(id));

            EditCarCommand model = mapper.Map<EditCarCommand>(cars);
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles ="Owner")]
        [Authorize(Roles ="Moderator")]
        [Route("Car/{CarId}/Edit")]
        public async Task<IActionResult> Edit(EditCarCommand command)
        {
            if (!ModelState.IsValid)

            { return View(command); }

            await mediator.Send(command);

            return RedirectToAction(nameof(Index));

        }
        [Authorize]
        [Route("Car/{Id}/Rent")]
        public async Task<IActionResult> Rent()
        {
            

            return View();
        }
        [HttpPost]
        [Authorize]
        [Route("Car/{CarId}/Rent")]
        public async Task<IActionResult> Rent(CreateNewRentCommand command)
        {
            if (!ModelState.IsValid)

            { return View(command); }

            await mediator.Send(command);

            return RedirectToAction(nameof(Index));

        }






    }
}
