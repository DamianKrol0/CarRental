using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CarRental.Application.User.Commands.AddUserToRole
{
    public class AddUserToRoleCommand(IdentityUser user, string roleName) : IRequest
    {
       

        public IdentityUser User { get; } = user;
        public string RoleName { get; } = roleName;
    }
    public class AddUserToRoleCommandHandler(UserManager<IdentityUser> userManager) : IRequestHandler<AddUserToRoleCommand>
    {
        private readonly UserManager<IdentityUser> _userManager = userManager;

        public async Task Handle(AddUserToRoleCommand request, CancellationToken cancellationToken)
        {
             await _userManager.AddToRoleAsync(request.User, request.RoleName);
        }
    }
 
}
