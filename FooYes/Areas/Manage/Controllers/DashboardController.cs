using FooYes.Areas.Manage.ViewModels;
using FooYes.DAL;
using FooYes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "SuperAdmin, Admin, Editor")]
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            DashboardViewModel dashboardVM = new DashboardViewModel
            {
                Orders = _context.Orders.Include(x => x.OrderItems).ThenInclude(x => x.Meal).ThenInclude(x => x.Restaurant).ToList(),
                RiderRequests = _context.Riders.Where(x => x.Status == null).ToList(),
                NewContactMessages = _context.ContactMessages.Where(x=>x.CreatedAt>DateTime.Today.AddDays(-1)).ToList(),
                CommentRequests = _context.Comments.Where(x=>x.Status==null).ToList(),
                Subscribers = _context.EmailSubscribers.ToList(),
                MostOrderedRestaurants = _context.Restaurants.Include(x=>x.Meals).ThenInclude(x=>x.OrderItems).ThenInclude(x=>x.Order).OrderByDescending(x=>x.Meals.SelectMany(x=>x.OrderItems.Select(x=>x.Order)).Count()).Take(7).ToList()
            };
            return View(dashboardVM);
        }
    }
}
