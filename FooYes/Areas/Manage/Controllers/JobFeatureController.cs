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
    public class JobFeatureController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public JobFeatureController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.SelectedPage = page;
            double totalPage = _context.JobFeatures.Count() / 3d;
            ViewBag.TotalPage = Math.Ceiling(totalPage);
            List<JobFeature> jobFeatures = _context.JobFeatures.OrderByDescending(x => x.Id).Skip((page - 1) * 3).Take(3).ToList();
            return View(jobFeatures);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(JobFeature jobFeature)
        {
            if (!ModelState.IsValid) return NotFound();
            if (jobFeature.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Fayl boş buraxıla bilməz!");
                return View();
            }
            else
            {
                if (jobFeature.ImageFile.ContentType != "image/jpeg" && jobFeature.ImageFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("ImageFile", "Fayl-ın növü yalnız .jpg və ya .png ola bilər!");
                    return View();
                }

                if (jobFeature.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "Fayl-ın ölcüsü 2MB-dan böyük ola bilməz!");
                    return View();
                }

                jobFeature.Image = FileManager.Save(_env.WebRootPath, "uploads/jobfeatures", jobFeature.ImageFile);
            }
            _context.JobFeatures.Add(jobFeature);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            if (!ModelState.IsValid) return View();
            JobFeature jobFeature = _context.JobFeatures.FirstOrDefault(x => x.Id == id);
            if (jobFeature == null) return NotFound();
            return View(jobFeature);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(JobFeature jobFeature)
        {
            if (!ModelState.IsValid) return View();
            JobFeature existJobFeature = _context.JobFeatures.FirstOrDefault(x => x.Id == jobFeature.Id);
            if (existJobFeature == null) return NotFound();

            if (jobFeature.ImageFile != null)
            {
                if (jobFeature.ImageFile.ContentType != "image/jpeg" && jobFeature.ImageFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("ImageFile", "Fayl-ın növü yalnız .jpg və ya .png ola bilər!");
                    return View(jobFeature);
                }

                if (jobFeature.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "Fayl-ın ölcüsü 2MB-dan böyük ola bilməz!");
                    return View(jobFeature);
                }

                string fileName = FileManager.Save(_env.WebRootPath, "uploads/jobfeatures", jobFeature.ImageFile);
                if (existJobFeature.Image != null)
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/jobfeatures", existJobFeature.Image);
                }
                existJobFeature.Image = fileName;
            }
            existJobFeature.Title = jobFeature.Title;
            existJobFeature.Desc = jobFeature.Desc;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            JobFeature existJobFeature = _context.JobFeatures.FirstOrDefault(x => x.Id == id);
            if (existJobFeature == null)
            {
                return Json(new { status = 404 });
            }
            if (existJobFeature.Image != null)
            {
                FileManager.Delete(_env.WebRootPath, "uploads/jobfeatures", existJobFeature.Image);
            }
            _context.JobFeatures.Remove(existJobFeature);
            _context.SaveChanges();

            return Json(new { status = 200 });
        }
    }
}
