using AutoMapper;
using CarRental.Application.Rent.Command.DeleteRent;
using CarRental.Application.Rent.Queries.GetAllRents;
using CarRental.Application.Rent.Queries.GetRentById;
using CarRental.Application.Role.Commands.DeleteRole;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.MVC.Controllers
{
	public class RentController(IMediator mediator) : Controller
	{
		public async Task<IActionResult> Index()
		{
			var rents = await mediator.Send(new GetAllRentsQuery());
			return View(rents);
		}
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteRentCommand command)
        {

            await mediator.Send(command);

            return RedirectToAction("Index");
        }
    }
}
