using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;



namespace CarRental.Application.ApplicationUser
{


    public class UserContext :IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public CurrentUser? GetCurrentUser() {
        
            var user = _httpContextAccessor?.HttpContext?.User;
            if (user == null) { throw new Exception("Contex user is not present"); }

            if(user.Identity == null||!user.Identity.IsAuthenticated)
            { return null; }

            var id = user.FindFirst(c=>c.Type == ClaimTypes.NameIdentifier)!.Value;
            var email = user.FindFirst(c=>c.Type == ClaimTypes.Email)!.Value;
            var roles = user.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);

            return new CurrentUser(id, email, roles);
        
        }
    }

    public interface IUserContext
    {
        CurrentUser? GetCurrentUser();
    }
}
