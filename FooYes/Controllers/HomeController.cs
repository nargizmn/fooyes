using FooYes.DAL;
using FooYes.Models;
using FooYes.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public HomeController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            HomeViewModel homeVM = new HomeViewModel
            {
                Setting = _context.Settings.FirstOrDefault(),
                PopularCategories = _context.Categories.Where(x => !x.IsDeleted && x.IsPopular).Include(x=>x.Restaurants).ThenInclude(x=>x.Meals).Take(7).ToList(),
                TrendingCategories = _context.Categories.Where(x=> !x.IsDeleted && x.IsTrending).Take(5).ToList(),
                OrderFeatures = _context.OrderFeatures.ToList(),
                TopRatedRestaurants = _context.Restaurants.Where(x=>!x.IsDeleted).Include(x=> x.RestaurantImages).Include(x=>x.Category).Include(x=>x.Meals).Include(x=>x.Campaign).OrderByDescending(x=>x.Rate).Take(6).ToList()
            };
            return View(homeVM);
        }

        public IActionResult Contact()
        {
            HomeViewModel homeVM = new HomeViewModel
            {
                Setting = _context.Settings.FirstOrDefault(),
                ContactCards = _context.ContactCards.ToList()
            };
            return View(homeVM);
        }

        public IActionResult WorkWithUs()
        {
            HomeViewModel homeVM = new HomeViewModel
            {
                Faqs = _context.Faqs.ToList(),
                JobFeatures = _context.JobFeatures.ToList(),
                Setting = _context.Settings.FirstOrDefault()
            };
            return View(homeVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Subscribe(EmailSubscribeViewModel emailSubscribeVM)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Email is not valid! Please try again!";
                return RedirectToAction("index", "home");
            }
            if (User.IsInRole("Admin") || User.IsInRole("SuperAdmin") || User.IsInRole("Editor"))
            {
                TempData["Error"] = "This section is for guests and members only. You can not subscribe a newsletter!";
                return RedirectToAction("index", "home");
            }
            if (_context.EmailSubscribers.Any(x => x.MailAddress.ToUpper() == emailSubscribeVM.MailAddress.ToUpper()))
            {
                TempData["Error"] = "You have already subscribed our newsletter!";
                return RedirectToAction("index", "home");
            }
            EmailSubscriber emailSubscriber = new EmailSubscriber
            {
                MailAddress = emailSubscribeVM.MailAddress,
            };
            _context.EmailSubscribers.Add(emailSubscriber);
            _context.SaveChanges();
            TempData["Succeed"] = "You successfully subscribed our newsletter! Thank you!";
            return RedirectToAction("index", "home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult JobApply(AppliedRiderViewModel riderVM)
        {
            if (riderVM.TermsAccept == false)
            {
                TempData["Error"] = "You have to accept our terms and conditions before submitting the form";
                return RedirectToAction("workwithus", "home");
            }
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Please fill out all sections of the job apply form!";
                return RedirectToAction("workwithus", "home");
            }
            Rider rider = new Rider
            {
                Age = riderVM.Age,
                City = riderVM.City,
                Email = riderVM.Email,
                Gender=riderVM.Gender,
                JobSource = String.Join(", ", riderVM.JobSource),
                TermsAccept = riderVM.TermsAccept,
                VehicleType=riderVM.VehicleType,
                Fullname = riderVM.Fullname,
                Telephone = riderVM.Telephone,
                Status = null,
                IsDeleted=false,
                CreatedAt = DateTime.UtcNow.AddHours(4)
            };
            _context.Riders.Add(rider);
            _context.SaveChanges();
            TempData["Succeed"] = "You successfully submit as a rider! We will contact you soon!";
            return RedirectToAction("workwithus", "home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ContactMessage(ContactMessageViewModel contactMessageVM)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Inputs can not be null!";
                return RedirectToAction("contact");
            }
            if (User.IsInRole("Admin") || User.IsInRole("SuperAdmin") || User.IsInRole("Editor"))
            {
                TempData["Error"] = "This section is for guests and members only!";
                return RedirectToAction("contact");
            }
            if (!User.Identity.IsAuthenticated)
            {
                if (string.IsNullOrWhiteSpace(contactMessageVM.Name) || string.IsNullOrWhiteSpace(contactMessageVM.Email) || string.IsNullOrWhiteSpace(contactMessageVM.Message))
                {
                    TempData["Error"] = "Inputs can not be null!";
                    return RedirectToAction("contact");
                }
                ContactMessage contactMessage = new ContactMessage
                {
                    Name = contactMessageVM.Name,
                    Email = contactMessageVM.Email,
                    Message = contactMessageVM.Message,
                    CreatedAt = DateTime.UtcNow.AddHours(4),
                    IsUser = false
                };
                _context.ContactMessages.Add(contactMessage);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(contactMessageVM.Message))
                {
                    TempData["Error"] = "Message can not be null!";
                    return RedirectToAction("contact");
                }
                AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);
                ContactMessage contactMessage = new ContactMessage
                {
                    AppUserId = appUser.Id,
                    Name = contactMessageVM.Name,
                    Email = contactMessageVM.Email,
                    Message = contactMessageVM.Message,
                    CreatedAt = DateTime.UtcNow.AddHours(4),
                    IsUser = true
                };
                _context.ContactMessages.Add(contactMessage);
            }
            _context.SaveChanges();
            TempData["Succeed"] = "Your message was succesfully sent! Thanks!";
            return RedirectToAction("contact");
        }

        public IActionResult SeeWishlist()
        {
            if (User.Identity.IsAuthenticated)
            {
                AppUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
                if (user == null) return NotFound();
                List<Favourite> favourites = _context.Favourites
                        .Include(x => x.Restaurant).ThenInclude(x => x.Category)
                        .Include(x => x.Restaurant).ThenInclude(x => x.RestaurantImages)
                        .Include(x => x.Restaurant).ThenInclude(x => x.Campaign)
                        .Include(x => x.Restaurant).ThenInclude(x => x.Meals)
                        .OrderByDescending(x=>x.Id)
                        .Where(x => x.AppUserId == user.Id).ToList();
                List<Restaurant> restaurants = favourites.Select(x => x.Restaurant).Where(x=>!x.IsDeleted).ToList();
                ViewBag.Favourites = restaurants;
            }
            else
            {
                var cookieRestaurants = HttpContext.Request.Cookies["Wishlist"];
                if (cookieRestaurants == null)
                {
                    return View();
                }
                List<Restaurant> selectedRestaurants = JsonConvert.DeserializeObject<List<Restaurant>>(cookieRestaurants);
                List<Restaurant> restaurants = new List<Restaurant>();
                List<int> Ids = selectedRestaurants.Select(x => x.Id).ToList();
                foreach (var item in Ids)
                {
                    List<Restaurant> restaurants1 = _context.Restaurants.Include(x => x.Campaign).Include(x => x.Category).Include(x => x.RestaurantImages).Include(x => x.Meals).Where(x => !x.IsDeleted && x.Id == item).ToList();
                    restaurants.AddRange(restaurants1);
                }
                ViewBag.Favourites = restaurants;
            }
            
            return View();
        }


    }
}
