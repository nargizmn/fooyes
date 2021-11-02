using FooYes.Areas.Manage.ViewModels;
using FooYes.DAL;
using FooYes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles ="SuperAdmin")]
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(AppDbContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.SelectedPage = page;
            double totalPage = _context.AppUsers.Where(x => x.IsAdmin && x.UserName != User.Identity.Name).Count() / 3d;
            ViewBag.TotalPage = Math.Ceiling(totalPage);
            List<AppUser> admins = _context.AppUsers.Where(x => x.IsAdmin && x.UserName != User.Identity.Name).Skip((page - 1) * 3).Take(3).ToList();
            return View(admins);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdminCreateViewModel adminVM)
        {
            if (!ModelState.IsValid) return View();
            if (_userManager.Users.Any(x => x.NormalizedUserName == adminVM.UserName.ToUpper()))
            {
                ModelState.AddModelError("UserName", "Username already taken!");
                return View();
            }
            AppUser newAdmin = new AppUser
            {
                UserName = adminVM.UserName,
                Name = adminVM.Name,
                LastName = adminVM.LastName,
                IsAdmin = true
            };
            var result = await _userManager.CreateAsync(newAdmin, adminVM.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }
            await _userManager.AddToRoleAsync(newAdmin, adminVM.IdentityRole);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public async Task<IActionResult> Edit(string id)
        {
            AppUser admin = await _userManager.FindByIdAsync(id);
            if (admin == null) return NotFound();
            AdminUpdateViewModel adminUpdateVM = new AdminUpdateViewModel
            {
                UserName = admin.UserName,
                Name = admin.Name,
                LastName = admin.LastName
            };
            return View(adminUpdateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AdminUpdateViewModel adminUpdateVM, string id)
        {
            AppUser existAdmin = await _userManager.FindByIdAsync(id);
            if (existAdmin == null) return NotFound();
            if (existAdmin.UserName != adminUpdateVM.UserName && _userManager.Users.Any(x => x.NormalizedUserName == adminUpdateVM.UserName.ToUpper()))
            {
                ModelState.AddModelError("UserName", "Username already taken");
                return View();
            }
            var currentRole = _userManager.GetRolesAsync(existAdmin).Result.First();
            if (currentRole != adminUpdateVM.IdentityRole)
            {
                if (!_roleManager.RoleExistsAsync(adminUpdateVM.IdentityRole).Result)
                {
                    ModelState.AddModelError("", "Seçdiyiniz adda rol mövcud deyildir");
                    return View();
                }
                await _userManager.RemoveFromRoleAsync(existAdmin, currentRole);
                await _userManager.AddToRoleAsync(existAdmin, adminUpdateVM.IdentityRole);
            }
            if (!string.IsNullOrEmpty(adminUpdateVM.Password))
            {
                var removeResult = await _userManager.RemovePasswordAsync(existAdmin);
                if (!removeResult.Succeeded)
                {
                    foreach (var item in removeResult.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View();
                }
                var addResult = await _userManager.AddPasswordAsync(existAdmin, adminUpdateVM.Password);
                if (!addResult.Succeeded)
                {
                    foreach (var item in addResult.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View();
                }
            }
            existAdmin.UserName = adminUpdateVM.UserName;
            existAdmin.Name = adminUpdateVM.Name;
            existAdmin.LastName = adminUpdateVM.LastName;
            await _userManager.UpdateAsync(existAdmin);
            return RedirectToAction("index");
        }
        public async Task<IActionResult> Delete(string id)
        {
            AppUser existAdmin = await _userManager.FindByIdAsync(id);
            if (existAdmin == null) return Json(new { status = 404 });
            _context.AppUsers.Remove(existAdmin);
            _context.SaveChanges();
            return Json(new { status = 200 });
        }
    }
}
