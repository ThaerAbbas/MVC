using FirstPro.Models;
using FirstPro.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
            var role = _roleManager.Roles;
            return View(role);
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

        public IActionResult AddRoleToUser()
        {
            ViewBag.User = new SelectList(_userManager.Users, "Id", "UserName");
            ViewBag.Role = new SelectList(_roleManager.Roles, "Name", "Name");
            return View();
        }


   

        [HttpPost]
        public async Task<IActionResult> AddRoleToUser(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.AddToRoleAsync(user, roleName);

            return RedirectToAction("Index");
        }

        public IActionResult ShowAllUsers()
        {
            UserRoleViewModel Uvm = new UserRoleViewModel();

            return View(_userManager.Users);
        }

        public async Task<IActionResult> ShowUserRoles(string Id)
        {
           

            UserRoleViewModel Uvm = new UserRoleViewModel();
            var user = await _userManager.FindByIdAsync(Id);

            var assignedRoles = new List<string>(await _userManager.GetRolesAsync(user));
            Uvm.UserId = Id;
            Uvm.UserName = user.UserName;

            Uvm.Roles.AddRange(assignedRoles);

            return View(Uvm);
        }
        public async Task<IActionResult> RemoveRoleFromUser(string rolename, string userid)
        {
            var user = await _userManager.FindByIdAsync(userid);

            await _userManager.RemoveFromRoleAsync(user, rolename);

            return RedirectToAction("ShowUserRoles", new { id = userid });
        }

    }
}

