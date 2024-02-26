using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CarRental.Application.User.Queries.FindUserById
{
    public class FindUserByIdQuery(string Id) : IRequest<IdentityUser>
    {
        public string Id { get; } = Id;
    }
    public class FindUserByIdQueryHandler(UserManager<IdentityUser> userManager) : IRequestHandler<FindUserByIdQuery, IdentityUser>
    {
        private readonly UserManager<IdentityUser> _userManager = userManager;

        public async Task<IdentityUser> Handle(FindUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            return user;
        }
    }

}
