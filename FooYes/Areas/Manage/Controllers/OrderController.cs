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
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IEmailService _emailService;

        public OrderController(AppDbContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.SelectedPage = page;
            double totalPage = _context.Orders.Count() / 3d;
            ViewBag.TotalPage = Math.Ceiling(totalPage);
            List<Order> orders = _context.Orders.Include(x => x.OrderItems).ThenInclude(x=>x.Meal).ThenInclude(x=>x.Restaurant).Include(x => x.AppUser).OrderByDescending(x=>x.CreatedAt).Skip((page - 1) * 3).Take(3).ToList();
            return View(orders);
        }
        public IActionResult Detail(int id)
        {
            Order order = _context.Orders
                .Include(x=>x.Rider)
                .Include(x => x.OrderItems).ThenInclude(x => x.Meal).ThenInclude(x => x.Restaurant).ThenInclude(x=>x.Campaign)
                .Include(x => x.OrderItems).ThenInclude(x => x.Meal).ThenInclude(x=>x.MealSizes).ThenInclude(x=>x.Size)
                .Include(x => x.AppUser).FirstOrDefault(x => x.Id == id);
            if (order == null) return NotFound();
            Restaurant restaurant = order.OrderItems.Select(x => x.Meal.Restaurant).FirstOrDefault();
            ViewBag.Restaurant = restaurant;
            ViewBag.Riders = _context.Riders.Where(x=>x.Status==true).ToList();
            return View(order);
        }

        public IActionResult OrderAccept(int orderId, string note, int? riderId)
        {
            Order order = _context.Orders.Include(x => x.OrderItems).ThenInclude(x=>x.Meal).ThenInclude(x=>x.Restaurant).Include(x => x.AppUser).FirstOrDefault(x => x.Id == orderId);
            if (order == null) return Json(new { status = 404 });
            order.RiderId = riderId;
            if (order.DeliveryType == "Delivery")
            {
                if(order.RiderId==null) return Json(new { status = 400 });
            }
            
            order.Status = true;
            order.AdminNote = note;
            _context.SaveChanges();
            string body = string.Empty;
            using (StreamReader reader = new StreamReader("wwwroot/templates/accept.html"))
            {
                body = reader.ReadToEnd();
            }
            string hiddenHeader = "Your order has been accepted! Click to get more information!";
            string textHeader = "Your order has been accepted!";
            string mainText = $"Thank you for ordering from our {order.OrderItems.FirstOrDefault().Meal.Restaurant.Name} restaurant!";
            if (order.AdminNote != null)
            {
                string adminNote = $@"<h2 style=\""margin-top: 15px;\"">Note : {order.AdminNote}</h2>";
                mainText += adminNote;
            }
            body = body.Replace("{{hiddenHeader}}", hiddenHeader)
                    .Replace("{{textHeader}}", textHeader)
                    .Replace("{{mainText}}", mainText);
            _emailService.Send(order.AppUser.Email, "Your order has been accepted!", body);
            return Json(new { status = 200 });
        }

        public IActionResult OrderReject(int orderId, string note)
        {
            Order order = _context.Orders.Include(x => x.OrderItems).ThenInclude(x=>x.Meal).ThenInclude(x=>x.Restaurant).Include(x => x.AppUser).FirstOrDefault(x => x.Id == orderId);
            if (order == null) Json(new { status = 404 });
            if (string.IsNullOrWhiteSpace(note))
            {
                return Json(new { status = 400 });
            }
            order.Status = false;
            order.AdminNote = note;
            _context.SaveChanges();

            string body = string.Empty;
            using (StreamReader reader = new StreamReader("wwwroot/templates/reject.html"))
            {
                body = reader.ReadToEnd();
            }
            string hiddenHeader = "Your order has been rejected! Click to get more information!";
            string textHeader = "Your order has been rejected!";
            string mainText = $"We are sorry to announce that your order from {order.OrderItems.FirstOrDefault().Meal.Restaurant.Name} restaurant has been rejected! You can check the details down below.";
            body = body.Replace("{{hiddenHeader}}", hiddenHeader)
                    .Replace("{{textHeader}}", textHeader)
                    .Replace("{{mainText}}", mainText)
                    .Replace("{{AdminNote}}", note);
            _emailService.Send(order.AppUser.Email, "Your order has been rejected!", body);
            return Json(new { status = 200 });
        }
    }
}
