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
    public class OrderFeatureController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public OrderFeatureController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index(int page=1)
        {
            ViewBag.SelectedPage = page;
            double totalPage = _context.OrderFeatures.Count() / 3d;
            ViewBag.TotalPage = Math.Ceiling(totalPage);
            List<OrderFeature> orderFeatures = _context.OrderFeatures.OrderByDescending(x => x.Id).Skip((page - 1) * 3).Take(3).ToList();
            return View(orderFeatures);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OrderFeature orderFeature)
        {
            if (!ModelState.IsValid) return NotFound();
            if (orderFeature.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Fayl boş buraxıla bilməz!");
                return View();
            }
            else
            {
                if (orderFeature.ImageFile.ContentType != "image/jpeg" && orderFeature.ImageFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("ImageFile", "Fayl-ın növü yalnız .jpg və ya .png ola bilər!");
                    return View();
                }

                if (orderFeature.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "Fayl-ın ölcüsü 2MB-dan böyük ola bilməz!");
                    return View();
                }

                orderFeature.Image = FileManager.Save(_env.WebRootPath, "uploads/orderfeatures", orderFeature.ImageFile);
            }
            _context.OrderFeatures.Add(orderFeature);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            if (!ModelState.IsValid) return View();
            OrderFeature orderFeature = _context.OrderFeatures.FirstOrDefault(x => x.Id == id);
            if (orderFeature == null) return NotFound();
            return View(orderFeature);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(OrderFeature orderFeature)
        {
            if (!ModelState.IsValid) return View();
            OrderFeature existOrderFeature = _context.OrderFeatures.FirstOrDefault(x => x.Id == orderFeature.Id);
            if (existOrderFeature == null) return NotFound();

            if (orderFeature.ImageFile != null)
            {
                if (orderFeature.ImageFile.ContentType != "image/jpeg" && orderFeature.ImageFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("ImageFile", "Fayl-ın növü yalnız .jpg və ya .png ola bilər!");
                    return View(orderFeature);
                }

                if (orderFeature.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "Fayl-ın ölcüsü 2MB-dan böyük ola bilməz!");
                    return View(orderFeature);
                }

                string fileName = FileManager.Save(_env.WebRootPath, "uploads/orderfeatures", orderFeature.ImageFile);
                if (existOrderFeature.Image != null)
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/orderfeatures", existOrderFeature.Image);
                }
                existOrderFeature.Image = fileName;
            }
            existOrderFeature.Title = orderFeature.Title;
            existOrderFeature.Subtitle = orderFeature.Subtitle;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            OrderFeature existOrderFeature = _context.OrderFeatures.FirstOrDefault(x => x.Id == id);
            if (existOrderFeature == null)
            {
                return Json(new { status = 404 });
            }
            if (existOrderFeature.Image != null)
            {
                FileManager.Delete(_env.WebRootPath, "uploads/orderfeatures", existOrderFeature.Image);
            }
            _context.OrderFeatures.Remove(existOrderFeature);
            _context.SaveChanges();

            return Json(new { status = 200 });
        }
    }
}
