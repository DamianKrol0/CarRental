﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CarRental.Application.CarRental.Queries.GetAllCars
{
    public class GetAllCarsQuery :IRequest<IEnumerable<CarsDto>>
    {
    }
}