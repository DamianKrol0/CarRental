using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CarRental.Application.CarRental.Queries.GetCArbyId
{
    public class GetCarByIdQuery :IRequest<CarsDto>
    {
        public GetCarByIdQuery(int Id)
        {
            this.Id = Id;
        }

        public int Id { get; set; }
    }
}
