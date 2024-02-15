using System.ComponentModel.DataAnnotations;
using System.Data;
using CarRental.Application.ApplicationUser;
using CarRental.MVC.Controllers;
using Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{
    
    public class RoleController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userMrg;

        public RoleController(RoleManager<IdentityRole> roleMgr, UserManager<IdentityUser> userMrg)
        {
            _roleManager = roleMgr;
            _userMrg = userMrg;
        }
        [Authorize(Roles = "Owner")]
        public ViewResult Index() => View(_roleManager.Roles);

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }
        [Authorize(Roles = "Owner")]
        public IActionResult Create() => View();
        [Authorize(Roles = "Owner")]
        [HttpPost]
        public async Task<IActionResult> Create([Required] string name)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            return View(name);
        }
        [Authorize(Roles = "Owner")]
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            else
                ModelState.AddModelError("", "No role found");
            return View("Index", _roleManager.Roles);
        }
        [Authorize(Roles = "Owner")]
        public async Task<IActionResult> Update(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            List<IdentityUser> members = new List<IdentityUser>();
            List<IdentityUser> nonMembers = new List<IdentityUser>();
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
