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
    [Authorize(Roles ="SuperAdmin, Admin, Editor")]
    public class CampaignController : Controller
    {
        private readonly AppDbContext _context;

        public CampaignController(AppDbContext context)
        {
            _context = context;
        } 
        public IActionResult Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            double totalPage = _context.Campaigns.Where(x => !x.IsDeleted).Count() / 3d;
            ViewBag.TotalPage = Math.Ceiling(totalPage);
            List<Campaign> campaigns = _context.Campaigns.Where(x => !x.IsDeleted).OrderByDescending(x => x.ExpireDate).Skip((page - 1) * 3).Take(3).ToList();
            return View(campaigns);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Campaign campaign)
        {
            if (!ModelState.IsValid) return View();
            _context.Campaigns.Add(campaign);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            if (!ModelState.IsValid) return View();
            Campaign campaign = _context.Campaigns.Where(x => !x.IsDeleted).FirstOrDefault(x => x.Id == id);
            if (campaign == null) return NotFound();
            return View(campaign);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Campaign campaign)
        {
            if (!ModelState.IsValid) return View();
            Campaign existCampaign = _context.Campaigns.Where(x => !x.IsDeleted).FirstOrDefault(x => x.Id == campaign.Id);
            if (existCampaign == null) return NotFound();
            existCampaign.DiscountPercent = campaign.DiscountPercent;
            existCampaign.ExpireDate = campaign.ExpireDate;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            Campaign existCampaign = _context.Campaigns.Where(x => !x.IsDeleted).FirstOrDefault(x => x.Id == id);
            if (existCampaign == null)
            {
                return Json(new { status = 404 });
            }
            existCampaign.IsDeleted = true;
            _context.SaveChanges();

            return Json(new { status = 200 });
        }

        
    }
}
