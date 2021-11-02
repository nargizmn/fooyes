using FooYes.DAL;
using FooYes.Models;
using FooYes.ViewModels;
using GodDamnEduHome.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IEmailService _emailService;

        public AccountController(AppDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IEmailService emailService)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegisterViewModel userRegisterVM)
        {
            if (!ModelState.IsValid) return View();
            if (_userManager.Users.Any(x => x.NormalizedUserName == userRegisterVM.Username.ToUpper()))
            {
                ModelState.AddModelError("Username", "Username already taken");
                return View();
            }
            if (_userManager.Users.Any(x => x.NormalizedEmail == userRegisterVM.Email.ToUpper()))
            {
                ModelState.AddModelError("Email", "Email already taken");
                return View();
            }
            AppUser user = new AppUser
            {
                UserName = userRegisterVM.Username,
                Name = userRegisterVM.Name,
                LastName = userRegisterVM.LastName,
                Email = userRegisterVM.Email,
                IsAdmin = false
            };
            var result = await _userManager.CreateAsync(user, userRegisterVM.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                    return View();
                }
            }
            await _userManager.AddToRoleAsync(user, "Member");
            TempData["Succeed"] = "You succesfully registered";
            return RedirectToAction("login");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginViewModel loginVM)
        {
            if (!ModelState.IsValid) return View();
            AppUser user = await _userManager.FindByNameAsync(loginVM.Username);
            if (user == null || user.IsAdmin)
            {
                ModelState.AddModelError("", "The username or password is not valid!");
                return View();
            }
            var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, true, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "The username or password is not valid!");
                return View();
            }
            return RedirectToAction("index", "home");
        }

        [Authorize(Roles = "Member")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        [Authorize(Roles = "Member")]
        public async Task<IActionResult> Edit()
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null) return RedirectToAction("notfound", "error");
            UserUpdateViewModel userUpdateVM = new UserUpdateViewModel
            {
                Email = user.Email,
                Name = user.Name,
                LastName = user.LastName,
                Username = user.UserName,
            };
            return View(userUpdateVM);
        }

        [Authorize(Roles = "Member")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserUpdateViewModel userUpdateVM)
        {
            if (!ModelState.IsValid) return View();
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null) return NotFound();
            var checkPassword = await _userManager.CheckPasswordAsync(user, userUpdateVM.CurrentPassword);
            if (!checkPassword)
            {
                ModelState.AddModelError("CurrentPassword", "Your Current Password is not valid. Please, try again!");
                return View();
            }
            if (user.UserName != userUpdateVM.Username && _userManager.Users.Any(x => x.NormalizedUserName == userUpdateVM.Username.ToUpper()))
            {
                ModelState.AddModelError("Username", "Username already taken!");
                return View();
            }
            if (user.Email != userUpdateVM.Email && _userManager.Users.Any(x => x.NormalizedEmail == userUpdateVM.Email.ToUpper()))
            {
                ModelState.AddModelError("Email", "Email already taken!");
                return View();
            }
            if (!string.IsNullOrEmpty(userUpdateVM.Password))
            {
                var result = await _userManager.ChangePasswordAsync(user, userUpdateVM.CurrentPassword, userUpdateVM.Password);
                if (!result.Succeeded)
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View();
                }
            }
            user.UserName = userUpdateVM.Username;
            user.Name = userUpdateVM.Name;
            user.LastName = userUpdateVM.LastName;
            user.Email = userUpdateVM.Email;
            user.Image = userUpdateVM.Image;
            await _userManager.UpdateAsync(user);
            await _signInManager.SignInAsync(user, true);
            TempData["Succeed"] = "Your profile edited successfully!";
            return RedirectToAction("index", "home");
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel forgotPasswordVM)
        {
            AppUser user = await _userManager.FindByEmailAsync(forgotPasswordVM.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Email is not valid");
                return View();
            }
            string token = await _userManager.GeneratePasswordResetTokenAsync(user);
            string callbackUrl = Url.Action("resetpassword", "account", new { token, email = user.Email }, Request.Scheme);
            string body = string.Empty;
            using (StreamReader reader = new StreamReader("wwwroot/templates/forgotpassword.html"))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{{url}}", callbackUrl);
            _emailService.Send(user.Email, "Reset Password", body);
            TempData["Succeed"] = "Please check your email - we have sent a message to help you!";
            return View();
        }

        public IActionResult ResetPassword(string token, string email)
        {
            ResetPasswordViewModel resetPasswordVM = new ResetPasswordViewModel
            {
                Token = token,
                Email = email
            };
            return View(resetPasswordVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordVM)
        {
            if (!ModelState.IsValid) return View(resetPasswordVM);
            AppUser user = await _userManager.FindByEmailAsync(resetPasswordVM.Email);
            var result = await _userManager.ResetPasswordAsync(user, resetPasswordVM.Token, resetPasswordVM.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(resetPasswordVM);
            }
            TempData["Succeed"] = "You successfully changed your password!";
            return RedirectToAction("login");
        }
    }
}
