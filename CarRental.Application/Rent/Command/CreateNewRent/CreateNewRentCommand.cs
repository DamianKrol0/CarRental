using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarRental.Application.ApplicationUser;
using CarRental.Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace CarRental.Application.Rent.Command.CreateNewRent
{
    public class CreateNewRentCommand : RentDto, IRequest
    {
    }
    public class CreateNewRentCommandHandler(IRentRepository repository, IMapper mapper, IUserContext userContext) : IRequestHandler<CreateNewRentCommand>
    {
        private readonly IRentRepository _repository = repository;
        private readonly IMapper _mapper = mapper;
        private readonly IUserContext _userContext = userContext;

        public async Task Handle(CreateNewRentCommand request, CancellationToken cancellationToken)
        {
            var user = _userContext.GetCurrentUser();

            if (user != null)
            {
                var rent = _mapper.Map<Domain.Entities.Rents>(request);
                rent.CreatedById = user.id;
                await _repository.Create(rent);
            }
        }
    }
    public class CreateNewRentCommandValidator : AbstractValidator<CreateNewRentCommand>

    {
        public CreateNewRentCommandValidator()
        {
            RuleFor(c => c.StartDate).NotEmpty().LessThanOrEqualTo(c => c.EndDate);




            RuleFor(c => c.EndDate).NotEmpty();

        }
    }
}
