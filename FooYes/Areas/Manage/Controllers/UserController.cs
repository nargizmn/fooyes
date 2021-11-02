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
    [Authorize(Roles = "SuperAdmin")]
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(AppDbContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.SelectedPage = page;
            double totalPage = _context.AppUsers.Where(x => !x.IsAdmin).Count() / 3d;
            ViewBag.TotalPage = Math.Ceiling(totalPage);
            List<AppUser> users = _context.AppUsers.Where(x => !x.IsAdmin).Skip((page - 1) * 3).Take(3).ToList();
            return View(users);
        }
    }
}
