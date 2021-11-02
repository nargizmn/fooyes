using FooYes.Areas.Manage.ViewModels;
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
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        //public async Task<IActionResult> Create()
        //{
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "SuperAdmin" });
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Editor" });
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Member" });

        //    return Ok();
        //}

        //public async Task<IActionResult> CreateAdmin()
        //{
        //    AppUser superAdmin = new AppUser
        //    {
        //        UserName = "SuperAdmin"
        //    };
        //    await _userManager.CreateAsync(superAdmin, "123456");
        //    await _userManager.AddToRoleAsync(superAdmin, "SuperAdmin");
        //    return Ok();
        //}

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AdminLoginViewModel adminLoginVM)
        {
            if (!ModelState.IsValid) return View();
            AppUser admin = await _userManager.FindByNameAsync(adminLoginVM.UserName);
            if (admin == null || admin.IsAdmin == false)
            {
                ModelState.AddModelError("", "Username və ya şifrə yanlışdır");
                return View();
            }
            var result = await _signInManager.PasswordSignInAsync(admin, adminLoginVM.Password, true, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Username və ya şifrə yanlışdır");
                return View();
            }
            return RedirectToAction("index", "dashboard");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("login", "account");
        }

        [Authorize(Roles ="SuperAdmin, Admin, Editor")]
        public async Task<IActionResult> Edit()
        {
            AppUser admin = await _userManager.FindByNameAsync(User.Identity.Name);
            AdminUpdateViewModel updateAdmin = new AdminUpdateViewModel
            {
                UserName = admin.UserName,
                Name = admin.Name,
                LastName = admin.LastName
            };
            return View(updateAdmin);
        }

        [Authorize(Roles = "SuperAdmin, Admin, Editor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AdminUpdateViewModel adminUpdateVM)
        {
            if (!ModelState.IsValid) return View();
            AppUser admin = await _userManager.FindByNameAsync(User.Identity.Name);
            var checkPassword = await _userManager.CheckPasswordAsync(admin, adminUpdateVM.CurrentPassword);
            if (!checkPassword)
            {
                ModelState.AddModelError("", "Your Current Password is not valid. Please, try again!");
                return View();
            }
            if (admin.UserName != adminUpdateVM.UserName && _userManager.Users.Any(x => x.NormalizedUserName == adminUpdateVM.UserName.ToUpper()))
            {
                ModelState.AddModelError("Username", "Username already taken!");
                return View();
            }
            if (!string.IsNullOrEmpty(adminUpdateVM.Password))
            {
                var result = await _userManager.ChangePasswordAsync(admin, adminUpdateVM.CurrentPassword, adminUpdateVM.Password);
                if (!result.Succeeded)
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View();
                }
            }
            admin.UserName = adminUpdateVM.UserName;
            admin.Name = adminUpdateVM.Name;
            admin.LastName = adminUpdateVM.LastName;
            await _userManager.UpdateAsync(admin);
            await _signInManager.SignInAsync(admin, true);
            return RedirectToAction("index", "dashboard");
        }
    }
}
