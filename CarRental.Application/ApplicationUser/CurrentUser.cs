using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Application.Rent;
using Microsoft.AspNetCore.Identity;

namespace CarRental.Application.ApplicationUser
{
    public class CurrentUser(string id, string email, IEnumerable<string> roles) : IdentityUser
    {
        public string id = id;
        public string email = email;
        public IEnumerable<string> roles = roles;

        public ICollection<RentDto>? Rents { get; set; }

        public bool IsInRole(string role)=>roles.Contains(role);

    }
}
