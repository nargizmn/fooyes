using FooYes.Areas.Manage.ViewModels;
using FooYes.DAL;
using FooYes.Models;
using GodDamnEduHome.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "SuperAdmin")]
    public class EmailSubscriberController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IEmailService _emailService;

        public EmailSubscriberController(AppDbContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        public IActionResult Index(int page=1)
        {
            ViewBag.SelectedPage = page;
            double totalPage = _context.EmailSubscribers.Count() / 10d;
            ViewBag.TotalPage = Math.Ceiling(totalPage);
            List<EmailSubscriber> emailSubscribers = _context.EmailSubscribers.OrderByDescending(x => x.Id).Skip((page - 1) * 10).Take(10).ToList();
            return View(emailSubscribers);
        }

        public IActionResult SendEmail()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SendEmail(SendEmailViewModel sendEmailVM)
        {
            if (!ModelState.IsValid) return View();
            List<EmailSubscriber> subscribers = _context.EmailSubscribers.ToList();

            string body = string.Empty;
            using (StreamReader reader = new StreamReader("wwwroot/templates/accept.html"))
            {
                body = reader.ReadToEnd();
            }
            string hiddenHeader = sendEmailVM.Header;
            string textHeader = sendEmailVM.Header;
            string mainText = sendEmailVM.Text;
            body = body.Replace("{{hiddenHeader}}", hiddenHeader)
                    .Replace("{{textHeader}}", textHeader)
                    .Replace("{{mainText}}", mainText);

            foreach (EmailSubscriber item in subscribers)
            {
                _emailService.Send(item.MailAddress, $"{sendEmailVM.Subject}", body);
            }

            return RedirectToAction("index");
        }
    }
}
