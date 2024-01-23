using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CarRental.Application.CarRental.Queries.GetCArbyId
{
    public class GetCarByIdQuery(int Id) : IRequest<CarsDto>
    {
        public int Id { get; set; } = Id;
    }
}
