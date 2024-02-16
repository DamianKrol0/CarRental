using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarRental.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CarRental.Application.Role.Commands.CreateNewRole
{
    public class CreateNewRoleCommand :IdentityRole,IRequest
    {
    }
    public class CreateNewRoleCommandHandler(IMapper mapper, RoleManager<IdentityRole> roleMgr) : IRequestHandler<CreateNewRoleCommand>
    {
        private readonly IMapper _mapper = mapper;
        private readonly RoleManager<IdentityRole> _roleMgr = roleMgr;

        public async Task Handle(CreateNewRoleCommand request, CancellationToken cancellationToken)
        {
            var role = _mapper.Map<IdentityRole>(request);
            
            await _roleMgr.CreateAsync(role);
        }
    }

}
