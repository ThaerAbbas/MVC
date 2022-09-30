﻿using FirstPro.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FirstPro.Controllers
{
    public class RoleController : Controller
    {
        readonly RoleManager<IdentityRole> _roleManager;
        readonly UserManager<FirstProUser> _userManager;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<FirstProUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View(_roleManager.Roles);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            role.NormalizedName = role.Name.ToUpper();
            await _roleManager.CreateAsync(role);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            await _roleManager.DeleteAsync(role);
            return RedirectToAction("Index");
        }

        public IActionResult AddUserToRole()
        {
            ViewBag.Users = new SelectList(_userManager.Users, "Id", "UserName");
            ViewBag.Roles = new SelectList(_roleManager.Roles, "Name", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddUserToRole(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.AddToRoleAsync(user, roleName);

            return RedirectToAction("Index");
        }

        public IActionResult ShowAllUsers()
        {
            return View(_userManager.Users);
        }

        public async Task<IActionResult> ShowUserRoles(string Id)
        {
            UserRole userRole = new UserRole();
            var user = await _userManager.FindByIdAsync(Id);

            var assignedRoles = new List<string>(await _userManager.GetRolesAsync(user));
            userRole.UserId = Id;
            userRole.UserName = user.UserName;

            userRole.Roles.AddRange(assignedRoles);

            return View(userRole);
        }
        public async Task<IActionResult> RemoveRoleFromUser(string rolename, string userid)
        {
            var user = await _userManager.FindByIdAsync(userid);
            await _userManager.RemoveFromRoleAsync(user, rolename);
            return RedirectToAction("ShowUserRoles", new { id = userid });
        }

    }
}
