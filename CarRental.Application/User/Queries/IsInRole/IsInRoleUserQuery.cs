using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarRental.Application.Rent;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CarRental.Application.User.Queries.IsInRole
{
    public class IsInRoleUserQuery(IdentityUser user, string role) : IRequest<bool>
    {
        public IdentityUser User { get; } = user;
        public string Role { get; } = role;
    }
    public class IsInRoleUserQueryHandler(UserManager<IdentityUser> userMrg) : IRequestHandler<IsInRoleUserQuery, bool>
    {

        private readonly UserManager<IdentityUser> _userMgr = userMrg;

        public async Task<bool> Handle(IsInRoleUserQuery request, CancellationToken cancellationToken)
        {
            bool res = await _userMgr.IsInRoleAsync(request.User, request.Role);
            return res;
        }
    }
}
