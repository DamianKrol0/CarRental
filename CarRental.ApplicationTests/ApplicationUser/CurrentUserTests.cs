using Xunit;
using CarRental.Application.ApplicationUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace CarRental.Application.ApplicationUser.Tests
{
    public class CurrentUserTests
    {
        [Fact()]
        public void IsInRole_WithMatchingRole_ShouldReturnTrue()
        {
            //arrange
            var currentUser = new CurrentUser("1","damian@test.com", new List<string> { "Admin","Moderator"});

            //act

            var isInRole = currentUser.IsInRole("Admin");
            //assert

            isInRole.Should().BeTrue();
        }
        [Fact()]
        public void IsInRole_WithNoMatchingRole_ShouldReturnTrue()
        {
            //arrange
            var currentUser = new CurrentUser("1", "damian@test.com", new List<string> { "Admin", "Moderator" });

            //act

            var isInRole = currentUser.IsInRole("Owner");
            //assert

            isInRole.Should().BeFalse();
        }

    }
}