using FooYes.DAL;
using FooYes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles ="SuperAdmin, Admin")]
    public class ContactMessageController : Controller
    {
        private readonly AppDbContext _context;

        public ContactMessageController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            double totalPage = _context.ContactMessages.Count() / 3d;
            ViewBag.TotalPage = Math.Ceiling(totalPage);
            List<ContactMessage> contactMessages = _context.ContactMessages.Include(x => x.AppUser).OrderByDescending(x => x.Id).Skip((page - 1) * 3).Take(3).ToList();
            return View(contactMessages);
        }
    }
}
