using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.ApplicationUser
{
    public class CurrentUser(string id, string email, IEnumerable<string> roles)
    {
        public string id = id;
        public string email = email;
        public IEnumerable<string> roles = roles;

        public bool IsInRole(string role)=>roles.Contains(role);

    }
}
