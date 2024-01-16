using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CarRental.Application.CarRental.Commands.EditCar
{
    public class EditCarCommand : CarsDto,IRequest
    {
    }
}
