using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CarRental.Application.Role.Commands.DeleteRole
{
    public class DeleteRoleCommand:IdentityRole,IRequest
    {
    }
    public class DeleteRoleCommandHandler(RoleManager<IdentityRole> roleMgr, IMapper mapper) : IRequestHandler<DeleteRoleCommand>
    {
        private readonly IMapper _mapper = mapper;
        private readonly RoleManager<IdentityRole> _roleMgr = roleMgr;

        public async Task Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var role = _mapper.Map<IdentityRole>(request);
            await _roleMgr.DeleteAsync(role);
        }
    }
}
