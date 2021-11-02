using FooYes.DAL;
using FooYes.Models;
using GodDamnEduHome.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes.Areas.Manage.Controllers
{
    [Area("manage")]
    public class RiderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IEmailService _emailService;

        public RiderController(AppDbContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        [Authorize(Roles = "SuperAdmin")]
        public IActionResult Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            double totalPage = _context.Riders.Where(x => !x.IsDeleted && x.Status == true).Count() / 3d;
            ViewBag.TotalPage = Math.Ceiling(totalPage);
            List<Rider> riders = _context.Riders.Where(x=> !x.IsDeleted && x.Status == true).OrderByDescending(x => x.CreatedAt).Skip((page - 1) * 3).Take(3).ToList();
            return View(riders);
        }

        [Authorize(Roles = "SuperAdmin")]
        public IActionResult SeeAll(int page=1)
        {
            ViewBag.SelectedPage = page;
            double totalPage = _context.Riders.Count() / 3d;
            ViewBag.TotalPage = Math.Ceiling(totalPage);
            List<Rider> riders = _context.Riders.OrderByDescending(x => x.CreatedAt).Skip((page - 1) * 3).Take(3).ToList();
            return View(riders);
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        public IActionResult Requests(int page = 1)
        {
            ViewBag.SelectedPage = page;
            double totalPage = _context.Riders.Where(x =>x.Status == null).Count() / 3d;
            ViewBag.TotalPage = Math.Ceiling(totalPage);
            List<Rider> riders = _context.Riders.Where(x=>x.Status == null).OrderByDescending(x => x.CreatedAt).Skip((page - 1) * 3).Take(3).ToList();
            return View(riders);
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        public IActionResult RiderDetails(int id)
        {
            Rider rider = _context.Riders.FirstOrDefault(x => x.Id == id);
            if (rider == null) return NotFound();
            return View(rider);
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        public IActionResult AcceptRider(int riderId, string note)
        {
            Rider rider = _context.Riders.FirstOrDefault(x => x.Id == riderId);
            if (rider == null) return NotFound();
            rider.Status = true;
            rider.AdminNote = note;
            _context.SaveChanges();

            string body = string.Empty;
            using (StreamReader reader = new StreamReader("wwwroot/templates/accept.html"))
            {
                body = reader.ReadToEnd();
            }
            string hiddenHeader = "Your job request has been accepted! Click to get more information!";
            string textHeader = "Welcome to the FooYes team!";
            string mainText = "We are happy to announce that your job request has been accepted! Our HR Professional will contact you soon for more details! Thank you for being a part of our team!";
            if (rider.AdminNote != null)
            {
                string adminNote = $@"<h2 style=\""margin-top: 15px;\"">Note : {rider.AdminNote}</h2>";
                mainText += adminNote;
            }
            body = body.Replace("{{hiddenHeader}}", hiddenHeader)
                    .Replace("{{textHeader}}", textHeader)
                    .Replace("{{mainText}}", mainText);
            _emailService.Send(rider.Email, "Welcome to our team!", body);
            return Json(new { status = 200 });
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        public IActionResult RejectRider(int riderId, string note)
        {
            Rider rider = _context.Riders.FirstOrDefault(x => x.Id == riderId);
            if (rider == null) return Json(new { status = 404 });
            if (string.IsNullOrWhiteSpace(note))
            {
                return Json(new { status = 400 });
            }
            rider.Status = false;
            rider.AdminNote = note;
            _context.SaveChanges();

            string body = string.Empty;
            using (StreamReader reader = new StreamReader("wwwroot/templates/accept.html"))
            {
                body = reader.ReadToEnd();
            }
            string hiddenHeader = "Your job request has been rejected! Click to get more information!";
            string textHeader = "Your request has been rejected!";
            string mainText = "We are sorry to announce that your job request has been accepted! You can contact with our HR Professionals to get more details.";
            body = body.Replace("{{hiddenHeader}}", hiddenHeader)
                    .Replace("{{textHeader}}", textHeader)
                    .Replace("{{mainText}}", mainText)
                    .Replace("{{AdminNote}}", note);
            _emailService.Send(rider.Email, "Your job request has been rejected!", body);
            return Json(new { status = 200 });
        }

        [Authorize(Roles = "SuperAdmin")]
        public IActionResult Delete(int id)
        {
            Rider existRider = _context.Riders.FirstOrDefault(x => x.Id == id);
            if (existRider == null)
            {
                return Json(new { status = 404 });
            }
            existRider.IsDeleted = true;
            _context.SaveChanges();
            return Json(new { status = 200 });
        }
    }
}
