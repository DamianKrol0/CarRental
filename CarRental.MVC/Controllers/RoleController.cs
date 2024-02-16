using System.ComponentModel.DataAnnotations;
using System.Data;
using CarRental.Application.ApplicationUser;
using CarRental.Application.Role.Commands.CreateNewRole;
using CarRental.Application.Role.Commands.DeleteRole;
using CarRental.MVC.Controllers;
using Identity.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Identity.Controllers
{
    
    public class RoleController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userMrg;
        private readonly IMediator _mediator;

        public RoleController(RoleManager<IdentityRole> roleMgr, UserManager<IdentityUser> userMrg, IMediator mediator)
        {
            _roleManager = roleMgr;
            _userMrg = userMrg;
            _mediator = mediator;
        }
        [Authorize(Roles = "Owner")]
        public ViewResult Index() => View(_roleManager.Roles);

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }
        [Authorize(Roles = "Owner")]
        public IActionResult Create() 
        { 
            return View(); 
        }
        [Authorize(Roles = "Owner")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateNewRoleCommand command)
        {
            if (!ModelState.IsValid)
            {
                  return View(command);    
            }
               await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Owner")]
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteRoleCommand command)
        {

            await _mediator.Send(command);

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Owner")]
        public async Task<IActionResult> Update(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            var members = new List<IdentityUser>();
            var nonMembers = new List<IdentityUser>();
            foreach (IdentityUser user in _userMrg.Users)
            {
                var list = await _userMrg.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                list.Add(user);
            }
            return View(new RoleEdit
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            });
        }
        [Authorize(Roles = "Owner")]
        [HttpPost]
        public async Task<IActionResult> Update(RoleModification model)
        {
            IdentityResult result;
            if (ModelState.IsValid)
            {
                foreach (string userId in model.AddIds ?? new string[] { })
                {
                    var user = await _userMrg.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await _userMrg.AddToRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                            Errors(result);
                    }
                }
                foreach (string userId in model.DeleteIds ?? new string[] { })
                {
                    var user = await _userMrg.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await _userMrg.RemoveFromRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                            Errors(result);
                    }
                }
            }

            if (ModelState.IsValid)
                return RedirectToAction(nameof(Index));
            else
                return await Update(model.RoleId);
        }
    }
}
