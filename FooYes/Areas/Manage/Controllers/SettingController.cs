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
    public class SettingController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SettingController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            Setting setting = _context.Settings.FirstOrDefault();
            return View(setting);
        }

        public IActionResult Edit()
        {
            Setting setting = _context.Settings.FirstOrDefault();
            if (setting == null) return NotFound();
            return View(setting);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Setting setting)
        {
            if (!ModelState.IsValid) return View();
            Setting existSetting = _context.Settings.FirstOrDefault();
            if (existSetting == null) return NotFound();

            #region CheckingImages

            if (setting.HeaderLogoImgFile != null)
            {
                if (setting.HeaderLogoImgFile.ContentType != "image/jpeg" && setting.HeaderLogoImgFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("HeaderLogoImgFile", "Fayl yalnız .jpg və ya .png ola bilər.");
                    return View();
                }

                if (setting.HeaderLogoImgFile.Length > 2097152)
                {
                    ModelState.AddModelError("HeaderLogoImgFile", "Fayl-ın ölcüsü 2MB-dan böyük ola bilməz!");
                    return View();
                }
            }
            if (setting.HeaderColorfulLogoImgFile != null)
            {
                if (setting.HeaderColorfulLogoImgFile.ContentType != "image/jpeg" && setting.HeaderColorfulLogoImgFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("HeaderColorfulLogoImgFile", "Fayl yalnız .jpg və ya .png ola bilər.");
                    return View();
                }

                if (setting.HeaderColorfulLogoImgFile.Length > 2097152)
                {
                    ModelState.AddModelError("HeaderColorfulLogoImgFile", "Fayl-ın ölcüsü 2MB-dan böyük ola bilməz!");
                    return View();
                }
            }
            if (setting.HomeHeroSecBgImgFile != null)
            {
                if (setting.HomeHeroSecBgImgFile.ContentType != "image/jpeg" && setting.HomeHeroSecBgImgFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("HomeHeroSecBgImgFile", "Fayl yalnız .jpg və ya .png ola bilər.");
                    return View();
                }

                if (setting.HomeHeroSecBgImgFile.Length > 2097152)
                {
                    ModelState.AddModelError("HomeHeroSecBgImgFile", "Fayl-ın ölcüsü 2MB-dan böyük ola bilməz!");
                    return View();
                }
            }
            if (setting.HomeBannerSecBgImgFile != null)
            {
                if (setting.HomeBannerSecBgImgFile.ContentType != "image/jpeg" && setting.HomeBannerSecBgImgFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("HomeBannerSecBgImgFile", "Fayl yalnız .jpg və ya .png ola bilər.");
                    return View();
                }

                if (setting.HomeBannerSecBgImgFile.Length > 2097152)
                {
                    ModelState.AddModelError("HomeBannerSecBgImgFile", "Fayl-ın ölcüsü 2MB-dan böyük ola bilməz!");
                    return View();
                }
            }
            if (setting.WorkWithUsHeroSecBgImgFile != null)
            {
                if (setting.WorkWithUsHeroSecBgImgFile.ContentType != "image/jpeg" && setting.WorkWithUsHeroSecBgImgFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("WorkWithUsHeroSecBgImgFile", "Fayl yalnız .jpg və ya .png ola bilər.");
                    return View();
                }

                if (setting.WorkWithUsHeroSecBgImgFile.Length > 2097152)
                {
                    ModelState.AddModelError("WorkWithUsHeroSecBgImgFile", "Fayl-ın ölcüsü 2MB-dan böyük ola bilməz!");
                    return View();
                }
            }
            if (setting.ContactHeroSecBgImgFile != null)
            {
                if (setting.ContactHeroSecBgImgFile.ContentType != "image/jpeg" && setting.ContactHeroSecBgImgFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("ContactHeroSecBgImgFile", "Fayl yalnız .jpg və ya .png ola bilər.");
                    return View();
                }

                if (setting.ContactHeroSecBgImgFile.Length > 2097152)
                {
                    ModelState.AddModelError("ContactHeroSecBgImgFile", "Fayl-ın ölcüsü 2MB-dan böyük ola bilməz!");
                    return View();
                }
            }

            #endregion

            existSetting.Address = setting.Address;
            existSetting.ContactHeroSecSubtitle = setting.ContactHeroSecSubtitle;
            existSetting.ContactHeroSecTitle = setting.ContactHeroSecTitle;
            existSetting.ContactMapUrl = setting.ContactMapUrl;
            existSetting.Email = setting.Email;
            existSetting.HomeBannerSecDesc = setting.HomeBannerSecDesc;
            existSetting.HomeBannerSecSubtitle = setting.HomeBannerSecSubtitle;
            existSetting.HomeBannerSecTitle = setting.HomeBannerSecTitle;
            existSetting.HomeHeroSecSubtitle = setting.HomeHeroSecSubtitle;
            existSetting.HomeHeroSecTitle = setting.HomeHeroSecTitle;
            existSetting.HomeOrderSecSubtitle1 = setting.HomeOrderSecSubtitle1;
            existSetting.HomeOrderSecSubtitle2 = setting.HomeOrderSecSubtitle2;
            existSetting.HomeOrderSecTitle = setting.HomeOrderSecTitle;
            existSetting.JobTerms = setting.JobTerms;
            existSetting.Phone = setting.Phone;
            existSetting.WorkWithUsHeroSecSubtitle = setting.WorkWithUsHeroSecSubtitle;
            existSetting.WorkWithUsHeroSecTitle = setting.WorkWithUsHeroSecTitle;

            if (setting.HeaderLogoImgFile != null)
            {
                string filename = FileManager.Save(_env.WebRootPath, "uploads/settings", setting.HeaderLogoImgFile);
                if (existSetting.HeaderLogoImgFile != null)
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/settings", existSetting.HeaderLogo);
                }
                existSetting.HeaderLogo = filename;
            }
            if (setting.HeaderColorfulLogoImgFile != null)
            {
                string filename = FileManager.Save(_env.WebRootPath, "uploads/settings", setting.HeaderColorfulLogoImgFile);
                if (existSetting.HeaderColorfulLogoImgFile != null)
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/settings", existSetting.HeaderColorfulLogo);
                }
                existSetting.HeaderColorfulLogo = filename;
            }
            if (setting.HomeHeroSecBgImgFile != null)
            {
                string filename = FileManager.Save(_env.WebRootPath, "uploads/settings", setting.HomeHeroSecBgImgFile);
                if (existSetting.HomeHeroSecBgImgFile != null)
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/settings", existSetting.HomeHeroSecBgImg);
                }
                existSetting.HomeHeroSecBgImg = filename;
            }
            if (setting.HomeBannerSecBgImgFile != null)
            {
                string filename = FileManager.Save(_env.WebRootPath, "uploads/settings", setting.HomeBannerSecBgImgFile);
                if (existSetting.HomeBannerSecBgImgFile != null)
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/settings", existSetting.HomeBannerSecBgImg);
                }
                existSetting.HomeBannerSecBgImg = filename;
            }
            if (setting.WorkWithUsHeroSecBgImgFile != null)
            {
                string filename = FileManager.Save(_env.WebRootPath, "uploads/settings", setting.WorkWithUsHeroSecBgImgFile);
                if (existSetting.WorkWithUsHeroSecBgImgFile != null)
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/settings", existSetting.WorkWithUsHeroSecBgImg);
                }
                existSetting.WorkWithUsHeroSecBgImg = filename;
            }
            if (setting.ContactHeroSecBgImgFile != null)
            {
                string filename = FileManager.Save(_env.WebRootPath, "uploads/settings", setting.ContactHeroSecBgImgFile);
                if (existSetting.ContactHeroSecBgImgFile != null)
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/settings", existSetting.ContactHeroSecBgImg);
                }
                existSetting.ContactHeroSecBgImg = filename;
            }
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
