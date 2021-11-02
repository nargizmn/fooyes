using FooYes.DAL;
using FooYes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "SuperAdmin, Admin, Editor")]
    public class FaqController : Controller
    {
        private readonly AppDbContext _context;

        public FaqController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            double totalPage = _context.Faqs.Count() / 3d;
            ViewBag.TotalPage = Math.Ceiling(totalPage);
            List<Faq> faqs = _context.Faqs.OrderByDescending(x => x.Id).Skip((page - 1) * 3).Take(3).ToList();
            return View(faqs);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Faq faq)
        {
            if (!ModelState.IsValid) return View();
            _context.Faqs.Add(faq);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            if (!ModelState.IsValid) return View();
            Faq faq = _context.Faqs.FirstOrDefault(x => x.Id == id);
            if (faq == null) return NotFound();
            return View(faq);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Faq faq)
        {
            if (!ModelState.IsValid) return View();
            Faq existFaq = _context.Faqs.FirstOrDefault(x => x.Id == faq.Id);
            if (existFaq == null) return NotFound();
            existFaq.Question = faq.Question;
            existFaq.Answer = faq.Answer;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            Faq existFaq = _context.Faqs.FirstOrDefault(x => x.Id == id);
            if (existFaq == null)
            {
                return Json(new { status = 404 });
            }
            _context.Faqs.Remove(existFaq);
            _context.SaveChanges();

            return Json(new { status = 200 });
        }
    }
}
