using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Application.ApplicationUser;
using CarRental.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace CarRental.Application.Rent
{
    public class RentDto
    {

        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CarId { get; set; }
        public Cars Car { get; set; }
        public string? CreatedById { get; set; }
        public string? CreatedBy { get; set; }
        

    }
}
