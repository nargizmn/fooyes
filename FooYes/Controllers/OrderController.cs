using FooYes.DAL;
using FooYes.Models;
using FooYes.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes.Controllers
{
    public class OrderController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _context;

        public OrderController(UserManager<AppUser> userManager, AppDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Checkout(int restaurantId, double subTotalPrice, string deliveryType, string deliveryDate, string deliveryTime)
        {
            if (!User.IsInRole("Member"))
            {
                return RedirectToAction("login", "account");
            }
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            Restaurant restaurant = _context.Restaurants.Where(x=>!x.IsDeleted).Include(x => x.Campaign).FirstOrDefault(x => x.Id == restaurantId);
            if (restaurant == null) return NotFound();
            if (deliveryType == null)
            {
                TempData["Error"] = "You have to choose delivery type";
                return RedirectToAction("detail", "restaurant", new { id = restaurant.Id });
            }
            ViewBag.Restaurant = restaurant;
            OrderCreateViewModel orderCreateVM = new OrderCreateViewModel
            {
                BasketItems = _context.BasketItems
                    .Include(x=>x.Size)
                    .Include(x => x.Meal).ThenInclude(x=>x.Restaurant)
                    .Include(x=>x.Meal).ThenInclude(x=>x.MealSizes).ThenInclude(x=>x.Size)
                    .Where(x => x.AppUserId == user.Id && x.Meal.RestaurantId==restaurantId).ToList(),
                Fullname = user.Name + " " + user.LastName,
                RestaurantId = restaurantId,
                SubTotalPrice = subTotalPrice,
                DeliveryDate = deliveryDate,
                DeliveryTime = deliveryTime,
                DeliveryType = deliveryType.ToUpper()
            };
            return View(orderCreateVM);
        } 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout(OrderCreateViewModel orderCreateVM)
        {
            if (!User.IsInRole("Member"))
            {
                return RedirectToAction("login", "account");
            }
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            Restaurant restaurant = _context.Restaurants.Where(x=>!x.IsDeleted).Include(x => x.Campaign).FirstOrDefault(x => x.Id == orderCreateVM.RestaurantId);
            if (restaurant == null) return NotFound();
            ViewBag.Restaurant = restaurant;
            List<BasketItem> basketItems = _context.BasketItems.Include(x => x.Meal).ThenInclude(x => x.Restaurant).Where(x => x.AppUserId == user.Id && x.Meal.RestaurantId == restaurant.Id).ToList();
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "You should fill all the fields!";
                return RedirectToAction("checkout", new { subTotalPrice = orderCreateVM.SubTotalPrice, restaurantId = orderCreateVM.RestaurantId, deliveryType = orderCreateVM.DeliveryType, deliveryDate = orderCreateVM.DeliveryDate, deliveryTime = orderCreateVM.DeliveryTime });
            }
            if (basketItems.Count() == 0)
            {
                TempData["Error"] = "Your Basket is empty!";
                return RedirectToAction("checkout", new { subTotalPrice = orderCreateVM.SubTotalPrice, restaurantId = orderCreateVM.RestaurantId, deliveryType = orderCreateVM.DeliveryType, deliveryDate = orderCreateVM.DeliveryDate, deliveryTime = orderCreateVM.DeliveryTime });
            }
            Order order = new Order
            {
                Address = orderCreateVM.Address,
                City = orderCreateVM.City,
                AppUserId = user.Id,
                CreatedAt = DateTime.UtcNow.AddHours(4),
                Fullname = orderCreateVM.Fullname,
                Phone=orderCreateVM.Phone,
                PostalCode=orderCreateVM.PostalCode,
                DeliveryDate = orderCreateVM.DeliveryDate,
                DeliveryTime = orderCreateVM.DeliveryTime,
                DeliveryType = orderCreateVM.DeliveryType,
                OrderItems = new List<OrderItem>()
            };
            foreach (BasketItem basketItem in basketItems)
            {
                OrderItem orderItem = new OrderItem
                {
                    MealId = basketItem.MealId,
                    Price = basketItem.Meal.Restaurant.Campaign!=null&& basketItem.Meal.Restaurant.Campaign.ExpireDate>=DateTime.Now?(double)basketItem.Meal.DiscountedPrice:basketItem.Meal.Price,
                    Count = basketItem.Count,
                    Name = basketItem.Meal.Name,
                    SizeId = basketItem.SizeId
                };
                order.OrderItems.Add(orderItem);
                if (order.DeliveryType.ToLower() == "delivery")
                {
                    order.TotalPrice = orderCreateVM.SubTotalPrice + restaurant.DeliveryFee;
                }
                else
                {
                    order.TotalPrice = orderCreateVM.SubTotalPrice;
                }
            }
            _context.Orders.Add(order);
            _context.BasketItems.RemoveRange(basketItems);
            _context.SaveChanges();
            return RedirectToAction("confirmed", new { id = restaurant.Id});
        }

        public IActionResult Confirmed(int id)
        {
            Restaurant restaurant = _context.Restaurants.FirstOrDefault(x => x.Id == id);
            if (restaurant == null) return NotFound();
            return View(restaurant);
        }

        public IActionResult SeeOrders(int page = 1)
        {
            if (!User.IsInRole("Member"))
            {
                return RedirectToAction("login", "account");
            }
            AppUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            ViewBag.SelectedPage = page;
            double totalPage = _context.Orders.Where(x => x.AppUserId == user.Id).Count() / 3d;
            ViewBag.TotalPage = Math.Ceiling(totalPage);
            if (user == null) return NotFound();
            List<Order> orders = _context.Orders.Include(x => x.OrderItems).ThenInclude(x => x.Meal).ThenInclude(x => x.Restaurant).Where(x => x.AppUserId == user.Id).OrderByDescending(x=>x.CreatedAt).Skip((page - 1) * 3).Take(3).ToList();
            return View(orders);
        }

        public IActionResult Detail(int id)
        {
            if (!User.IsInRole("Member"))
            {
                return RedirectToAction("login", "account");
            }
            AppUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            Order order = _context.Orders.Include(x => x.OrderItems).ThenInclude(x => x.Meal).ThenInclude(x=>x.MealSizes).ThenInclude(x=>x.Size)
                .Include(x => x.OrderItems).ThenInclude(x=>x.Meal).ThenInclude(x=>x.Restaurant).ThenInclude(x=>x.Campaign)
                .Include(x=>x.Rider)
                .FirstOrDefault(x => x.AppUserId == user.Id && x.Id == id);
            if (order == null) return NotFound();
            return View(order);
        }
    }
}
