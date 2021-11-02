using FooYes.DAL;
using FooYes.Helpers;
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

    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CategoryController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.SelectedPage = page;
            double totalPage = _context.Categories.Where(x => !x.IsDeleted).Count() / 5d;
            ViewBag.TotalPage = Math.Ceiling(totalPage);
            List<Category> categories = _context.Categories.Where(x => !x.IsDeleted).OrderByDescending(x => x.Id).Skip((page - 1) * 5).Take(5).ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid) return NotFound();
            if (category.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Fayl boş buraxıla bilməz!");
                return View();
            }
            else
            {
                if (category.ImageFile.ContentType != "image/jpeg" && category.ImageFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("ImageFile", "Fayl-ın növü yalnız .jpg və ya .png ola bilər!");
                    return View();
                }

                if (category.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "Fayl-ın ölcüsü 2MB-dan böyük ola bilməz!");
                    return View();
                }

                category.Image = FileManager.Save(_env.WebRootPath, "uploads/categories", category.ImageFile);
            }
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            if (!ModelState.IsValid) return View();
            Category category = _context.Categories.Where(x => !x.IsDeleted).FirstOrDefault(x => x.Id == id);
            if (category == null) return NotFound();
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (!ModelState.IsValid) return View();
            Category existCategory = _context.Categories.Where(x => !x.IsDeleted).FirstOrDefault(x => x.Id == category.Id);
            if (existCategory == null) return NotFound();

            if (category.ImageFile != null)
            {
                if (category.ImageFile.ContentType != "image/jpeg" && category.ImageFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("ImageFile", "Fayl-ın növü yalnız .jpg və ya .png ola bilər!");
                    return View(category);
                }

                if (category.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "Fayl-ın ölcüsü 2MB-dan böyük ola bilməz!");
                    return View(category);
                }

                string fileName = FileManager.Save(_env.WebRootPath, "uploads/categories", category.ImageFile);
                if (existCategory.Image != null)
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/categories", existCategory.Image);
                }
                existCategory.Image = fileName;
            }
            existCategory.Name = category.Name;
            existCategory.IsTrending = category.IsTrending;
            existCategory.IsPopular = category.IsPopular;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            Category existCategory = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (existCategory == null)
            {
                return Json(new { status = 404 });
            }
            if (existCategory.Image != null)
            {
                FileManager.Delete(_env.WebRootPath, "uploads/categories", existCategory.Image);
            }
            existCategory.IsDeleted = true;
            _context.SaveChanges();

            return Json(new { status = 200 });
        }
    }
}
