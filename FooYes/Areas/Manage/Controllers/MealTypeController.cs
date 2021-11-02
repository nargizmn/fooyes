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
    public class MealTypeController : Controller
    {
        private readonly AppDbContext _context;

        public MealTypeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            double totalPage = _context.MealTypes.Where(x => !x.IsDeleted).Count() / 3d;
            ViewBag.TotalPage = Math.Ceiling(totalPage);
            List<MealType> mealTypes = _context.MealTypes.Where(x => !x.IsDeleted).OrderByDescending(x => x.Id).Skip((page - 1) * 3).Take(3).ToList();
            return View(mealTypes);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MealType mealType)
        {
            if (!ModelState.IsValid) return View();
            _context.MealTypes.Add(mealType);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            if (!ModelState.IsValid) return View();
            MealType mealType = _context.MealTypes.Where(x => !x.IsDeleted).FirstOrDefault(x => x.Id == id);
            if (mealType == null) return NotFound();
            return View(mealType);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MealType mealType)
        {
            if (!ModelState.IsValid) return View();
            MealType existMealType = _context.MealTypes.Where(x => !x.IsDeleted).FirstOrDefault(x => x.Id == mealType.Id);
            if (existMealType == null) return NotFound();
            existMealType.Name = mealType.Name;
            existMealType.Order = mealType.Order;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            MealType existMealType = _context.MealTypes.FirstOrDefault(x => x.Id == id);
            if (existMealType == null)
            {
                return Json(new { status = 404 });
            }
            existMealType.IsDeleted = true;
            _context.SaveChanges();

            return Json(new { status = 200 });
        }
    }
}
