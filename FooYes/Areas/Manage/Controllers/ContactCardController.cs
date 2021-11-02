using FooYes.DAL;
using FooYes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "SuperAdmin, Admin, Editor")]

    public class ContactCardController : Controller
    {
        private readonly AppDbContext _context;

        public ContactCardController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int page=1)
        {
            ViewBag.SelectedPage = page;
            double totalPage = _context.ContactCards.Count() / 3d;
            ViewBag.TotalPage = Math.Ceiling(totalPage);
            List<ContactCard> contactCards = _context.ContactCards.OrderByDescending(x => x.Id).Skip((page - 1) * 3).Take(3).ToList();
            return View(contactCards);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ContactCard contactCard)
        {
            if (!ModelState.IsValid) return NotFound();
            _context.ContactCards.Add(contactCard);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            if (!ModelState.IsValid) return View();
            ContactCard contactCard = _context.ContactCards.FirstOrDefault(x => x.Id == id);
            if (contactCard == null) return NotFound();
            return View(contactCard);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ContactCard contactCard)
        {
            if (!ModelState.IsValid) return View();
            ContactCard existContactCard = _context.ContactCards.FirstOrDefault(x => x.Id == contactCard.Id);
            if (existContactCard == null) return NotFound();
            existContactCard.Title = contactCard.Title;
            existContactCard.Subtitle = contactCard.Subtitle;
            existContactCard.WorkingHours = contactCard.WorkingHours;
            existContactCard.Icon = contactCard.Icon;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            ContactCard existContactCard = _context.ContactCards.FirstOrDefault(x => x.Id == id);
            if (existContactCard == null)
            {
                return Json(new { status = 404 });
            }
            _context.ContactCards.Remove(existContactCard);
            _context.SaveChanges();

            return Json(new { status = 200 });
        }
    }
}
