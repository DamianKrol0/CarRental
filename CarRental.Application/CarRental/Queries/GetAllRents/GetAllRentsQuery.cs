using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarRental.Domain.Interfaces;
using MediatR;

namespace CarRental.Application.CarRental.Queries.GetAllRents
{
	public class GetAllRentsQuery :IRequest<IEnumerable<RentDto>>
	{
	}
	public class GetAllRentsQueryHandler(IRentRepository rentRepository, IMapper mapper) : IRequestHandler<GetAllRentsQuery, IEnumerable<RentDto>>
	{
		private readonly IRentRepository _rentRepository = rentRepository;
		private readonly IMapper _mapper = mapper;

		public async Task<IEnumerable<RentDto>> Handle(GetAllRentsQuery request, CancellationToken cancellationToken)
		{
			var rents = await _rentRepository.GetAll();
			var dtos = _mapper.Map<IEnumerable<RentDto>>(rents);
			return dtos;
 		}
	}
}
