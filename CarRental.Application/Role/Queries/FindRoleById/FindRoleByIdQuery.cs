using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CarRental.Application.Role.Queries.FindRoleById
{
    public class FindRoleByIdQuery(string id) : IRequest<IdentityRole>
    {
        public string Id { get; } = id;
    }
    public class FindRoleByIdQueryHandler(RoleManager<IdentityRole> roleMgr,IMapper mapper) :IRequestHandler<FindRoleByIdQuery,IdentityRole> 
    {
        private readonly RoleManager<IdentityRole> _roleMgr = roleMgr;
        private readonly IMapper _mapper = mapper;

        

        async Task<IdentityRole> IRequestHandler<FindRoleByIdQuery, IdentityRole>.Handle(FindRoleByIdQuery request, CancellationToken cancellationToken)
        {

            var role = await _roleMgr.FindByIdAsync(request.Id);
           
            return role;
        }
    }
}
