using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CarRental.Application.User.Commands.RemoveUserFromRole
{
    public class RemoveUserFromRoleCommand(IdentityUser identityUser, string roleName) : IRequest
    {
        public IdentityUser IdentityUser { get; } = identityUser;
        public string RoleName { get; } = roleName;
    }
    public class RemoveUserFromRoleCommandHandler(UserManager<IdentityUser> userManager) : IRequestHandler<RemoveUserFromRoleCommand>
    {
        private readonly UserManager<IdentityUser> _userManager = userManager;

        public async Task Handle(RemoveUserFromRoleCommand request, CancellationToken cancellationToken)
        {
            await _userManager.RemoveFromRoleAsync(request.IdentityUser,request.RoleName);
        }
    }
}
