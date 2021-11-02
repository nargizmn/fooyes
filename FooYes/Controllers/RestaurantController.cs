using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FooYes.DAL;
using FooYes.Models;
using FooYes.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;

namespace FooYes.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public RestaurantController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index(List<int> categoryIds, int? rate, int? categoryId, string sort, string deliveryType, string search, int page = 1)
        {
            var query = _context.Restaurants.Where(x=>!x.IsDeleted).Include(x => x.RestaurantImages).Include(x => x.Category).Include(x => x.Meals).Include(x => x.Campaign).AsQueryable();
            ViewBag.Categories = _context.Categories.Where(x=>!x.IsDeleted).Include(x => x.Restaurants).ToList();
            if (categoryIds.Count >= 1)
            {
                List<Restaurant> restaurants1 = new List<Restaurant>();
                foreach (var item in categoryIds)
                {
                    List<Restaurant> restaurants2 = _context.Restaurants.Include(x => x.RestaurantImages).Include(x => x.Category).Include(x => x.Meals).Include(x => x.Campaign).Where(x =>!x.IsDeleted && x.CategoryId == item).ToList();
                    restaurants1.AddRange(restaurants2);
                }
                query = restaurants1.AsQueryable();
            }
            if (rate != null)
            {
                query = query.Where(x => x.Rate >= rate);
            }
            if (search != null)
            {
                query = query.Where(x => x.Name.ToUpper().Contains(search.ToUpper()) || x.Meals.Any(x=>x.Name.ToUpper().Contains(search.ToUpper())));
            }
            if (deliveryType != null)
            {
                switch (deliveryType.ToLower())
                {
                    case "delivery":
                        query = query.Where(x => x.HasDelivery);
                        break;
                    case "takeaway":
                        query = query.Where(x => x.HasTakeAway);
                        break;
                    default:
                        break;
                }
            }
            if (sort != null)
            {
                switch (sort)
                {
                    case "toprated":
                            query = query.Where(x => x.Rate >= 8);
                        break;
                    case "recommended":
                        query = query.Where(x => x.IsRecommended);
                        break;
                    case "lowtohigh":
                        query = query.OrderBy(x => x.Meals.Select(x => x.Price).Average());
                        break;
                    case "15off":
                        query = query.Where(x => x.CampaignId!=null && x.Campaign.DiscountPercent>=15 && x.Campaign.ExpireDate >= DateTime.Now);
                        break;
                    default:
                        break;
                }
            }
            if (categoryId != null)
            {
                query = query.Where(x => x.CategoryId == categoryId);
            }
            ViewBag.SelectedPage = page;
            ViewBag.Search = search;
            ViewBag.DeliveryType = deliveryType;
            ViewBag.Rate = rate;
            ViewBag.Sort = sort;
            ViewBag.CategoryId = categoryId;
            ViewBag.CategoryIds = categoryIds;
            double totalPage = query.Count() / 9d;
            ViewBag.TotalPage = Math.Ceiling(totalPage);
            List<Restaurant> restaurants = query.Skip((page - 1) * 9).Take(9).ToList();
            return View(restaurants);
        }

        public IActionResult Detail(int id)
        {
            Restaurant restaurant = _context.Restaurants.Where(x => !x.IsDeleted)
                .Include(x => x.Category)
                .Include(x => x.Meals).ThenInclude(x => x.MealType)
                .Include(x => x.Meals).ThenInclude(x => x.MealSizes).ThenInclude(x=>x.Size)
                .Include(x => x.RestaurantImages)
                .Include(x => x.Campaign)
                .Include(x => x.Comments).ThenInclude(x => x.CommentRates)
                .Include(x=>x.Comments).ThenInclude(x => x.AppUser)
                .Include(x=>x.Favourites).ThenInclude(x=>x.AppUser)
                .FirstOrDefault(x => x.Id == id);

            if (restaurant == null) return NotFound();
            
            var restaurants = HttpContext.Request.Cookies["Wishlist"];
            if (restaurants != null)
            {
                List<Restaurant> cookieRestaurants = JsonConvert.DeserializeObject<List<Restaurant>>(restaurants);
                if (cookieRestaurants.Exists(x => x.Id == restaurant.Id))
                {
                    ViewBag.Clicked = "clicked";
                }
            }

            return View(restaurant);
        }

        public IActionResult AddToCartPartial(int id)
        {
            Meal meal = _context.Meals.Where(x => !x.IsDeleted).Include(x=>x.BasketItems).Include(x => x.MealSizes).ThenInclude(x => x.Size).FirstOrDefault(x => x.Id == id);
            if (meal == null) return NotFound();
            return PartialView("_AddToCart", meal);
        }

        [Authorize(Roles ="Member")]
        public IActionResult LeaveReview(int restaurantId)
        {
            ViewBag.Restaurant = _context.Restaurants.Where(x => !x.IsDeleted).FirstOrDefault(x => x.Id == restaurantId);
            AppUser appUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
            if (!_context.Orders.Any(x => x.AppUserId == appUser.Id && x.OrderItems.FirstOrDefault().Meal.RestaurantId == restaurantId))
            {
                TempData["Error"] = "Sorry, you can't review this restaurant, because you never ordered from it!";
                return RedirectToAction("detail", "restaurant", new { id = restaurantId });
            }
            if (_context.Comments.Where(x=>x.AppUserId==appUser.Id && x.RestaurantId==restaurantId).Count()==_context.Orders.Where(x=>x.AppUserId==appUser.Id && x.OrderItems.FirstOrDefault().Meal.RestaurantId ==restaurantId).Count())
            {
                TempData["Error"] = "You already reviewed this restaurant!";
                return RedirectToAction("detail", "restaurant", new { id = restaurantId });
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Member")]
        public async Task<IActionResult> LeaveReview(CreateCommentViewModel commentVM, int restaurantId)
        {
            ViewBag.Restaurant = _context.Restaurants.Where(x => !x.IsDeleted).FirstOrDefault(x => x.Id == restaurantId);
            AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            if (!ModelState.IsValid) return View();
            Restaurant restaurant = _context.Restaurants.Where(x => !x.IsDeleted).Include(x => x.Comments).FirstOrDefault(x => x.Id == commentVM.RestaurantId);
            if (restaurant == null) return NotFound();
            List<double> rateList = new List<double> { commentVM.FoodRate, commentVM.PriceRate, commentVM.PunctualityRate, commentVM.ServiceRate };
            Comment comment = new Comment
            {
                AppUserId = appUser.Id,
                Text = commentVM.Text,
                Rate = Math.Round(Queryable.Average(rateList.AsQueryable()), 1),
                FoodRate = commentVM.FoodRate,
                ServiceRate = commentVM.ServiceRate,
                PunctualityRate = commentVM.PunctualityRate,
                PriceRate = commentVM.PriceRate,
                CreatedAt = DateTime.UtcNow.AddHours(4),
                Title = commentVM.Title,
                Useful = 0,
                NotUseful = 0
            };
            restaurant.Comments.Add(comment);
            _context.SaveChanges();
            TempData["Succeed"] = "Thank you for your review. It has been submitted to the webmaster for approval.";
            return RedirectToAction("detail", "restaurant", new { id = commentVM.RestaurantId });
        }


        public IActionResult Useful(int id)
        { 
            Comment comment = _context.Comments.Include(x => x.AppUser).Include(x=>x.CommentRates).FirstOrDefault(x => x.Id == id);
            if (comment == null) return NotFound();
            if (!User.IsInRole("Member"))
            {
                TempData["Error"] = "You have to sign in first!";
                return RedirectToAction("detail", "restaurant", new { id = comment.RestaurantId });
            }
            AppUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            if (_context.CommentRates.Any(x=>x.IsUseful && x.CommentId==comment.Id && x.AppUserId == user.Id))
            {
                CommentRate usefulRate = _context.CommentRates.FirstOrDefault(x => x.IsUseful && x.CommentId == comment.Id && x.AppUserId == user.Id);
                comment.CommentRates.Remove(usefulRate);
                _context.SaveChanges();
                int usefuls = comment.CommentRates.Where(x => x.IsUseful).Count();
                int notUsefuls = comment.CommentRates.Where(x => !x.IsUseful).Count();
                List<int> allRates = new List<int> { usefuls, notUsefuls };
                return Json(allRates);
            }
            if (_context.CommentRates.Any(x => !x.IsUseful && x.CommentId == comment.Id && x.AppUserId == user.Id))
            {
                CommentRate notUsefulRate = _context.CommentRates.FirstOrDefault(x => !x.IsUseful && x.CommentId == comment.Id && x.AppUserId == user.Id);
                comment.CommentRates.Remove(notUsefulRate);
            }
            CommentRate commentRate = new CommentRate
            {
                CommentId = comment.Id,
                AppUserId = user.Id,
                IsUseful = true
            };
            if (comment.CommentRates.Count<1)
            {
                comment.CommentRates = new List<CommentRate>();
            }
            comment.CommentRates.Add(commentRate);
            _context.SaveChanges();
            int usefulRates = comment.CommentRates.Where(x => x.IsUseful).Count();
            int notUsefulRates = comment.CommentRates.Where(x => !x.IsUseful).Count();
            List<int> rates = new List<int> { usefulRates, notUsefulRates };
            return Json(rates);
        }


        public IActionResult NotUseful(int id)
        {
            Comment comment = _context.Comments.Include(x=>x.AppUser).Include(x=>x.CommentRates).FirstOrDefault(x => x.Id == id);
            if (comment == null) return NotFound();
            if (!User.IsInRole("Member"))
            {
                TempData["Error"] = "You have to sign in first!";
                return RedirectToAction("detail", "restaurant", new { id = comment.RestaurantId });
            }
            AppUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            if (_context.CommentRates.Any(x =>!x.IsUseful && x.CommentId == comment.Id && x.AppUserId == user.Id))
            {
                CommentRate notUsefulRate = _context.CommentRates.FirstOrDefault(x => !x.IsUseful && x.CommentId == comment.Id && x.AppUserId == user.Id);
                comment.CommentRates.Remove(notUsefulRate);
                _context.SaveChanges();
                int usefuls = comment.CommentRates.Where(x => x.IsUseful).Count();
                int notUsefuls = comment.CommentRates.Where(x => !x.IsUseful).Count();
                List<int> allRates = new List<int> { usefuls, notUsefuls };
                return Json(allRates);
            }
            if (_context.CommentRates.Any(x => x.IsUseful && x.CommentId == comment.Id && x.AppUserId == user.Id))
            {
                CommentRate usefulRate = _context.CommentRates.FirstOrDefault(x => x.IsUseful && x.CommentId == comment.Id && x.AppUserId == user.Id);
                comment.CommentRates.Remove(usefulRate);
            }
            CommentRate commentRate = new CommentRate
            {
                CommentId = comment.Id,
                AppUserId = user.Id,
                IsUseful = false
            };
            if (comment.CommentRates.Count<1)
            {
                comment.CommentRates = new List<CommentRate>();
            }
            comment.CommentRates.Add(commentRate);
            _context.SaveChanges();
            int usefulRates = comment.CommentRates.Where(x => x.IsUseful).Count();
            int notUsefulRates = comment.CommentRates.Where(x => !x.IsUseful).Count();
            List<int> rates = new List<int> { usefulRates, notUsefulRates };
            return Json(rates);
        }

        public IActionResult Search()
        {
            List<Restaurant> restaurants = _context.Restaurants.Where(x => !x.IsDeleted).Include(x => x.RestaurantImages).ToList();
            return Json(restaurants);
        }

        public IActionResult AddToCart(int id, int count, int? sizeId)
        {
            Meal meal = _context.Meals.Where(x => !x.IsDeleted).Include(x=>x.BasketItems).FirstOrDefault(x => x.Id == id);
            if (meal == null) return NotFound();
            if (User.Identity.IsAuthenticated && _userManager.Users.Any(x => x.UserName == User.Identity.Name && x.IsAdmin == false))
            {
                AppUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
                BasketItem basketItem = meal.BasketItems.FirstOrDefault(x => x.AppUserId == user.Id && x.SizeId==sizeId);

                if (basketItem != null)
                {
                    if (basketItem.SizeId != null && !meal.BasketItems.Any(x=>x.SizeId==sizeId))
                    {
                        basketItem = new BasketItem
                        {
                            AppUserId = user.Id,
                            Count = count,
                            MealId = id,
                            SizeId = sizeId
                        };
                        meal.BasketItems.Add(basketItem);
                    }
                    else
                    {
                        basketItem.Count += count;
                    }                  
                }
                else
                {
                    basketItem = new BasketItem
                    {
                        AppUserId = user.Id,
                        Count = count,
                        MealId = id,
                        SizeId = sizeId
                    };
                    meal.BasketItems.Add(basketItem);
                }
                TempData["Succeed"] = "Your item is successfully added to the cart";
                _context.SaveChanges();
            }
            else
            {
                TempData["Error"] = "You have to sign in for ordering!";
                return RedirectToAction("detail", new { id = meal.RestaurantId });
            }
            return RedirectToAction("detail", new { id = meal.RestaurantId });
        }

        public IActionResult RemoveItem(int mealId, int? sizeId)
        {
            Meal meal = _context.Meals.Where(x => !x.IsDeleted).FirstOrDefault(x => x.Id == mealId);
            if (meal == null) return NotFound();
            BasketViewModel basketData = new BasketViewModel
            {
                BasketItems = new List<BasketItemViewModel>(),
                TotalPrice = 0
            };
            BasketItem basketItem = _context.BasketItems.FirstOrDefault(x => x.MealId == meal.Id && x.SizeId == sizeId);
            if (basketItem != null)
            {
                if (basketItem.Count > 1)
                {
                    basketItem.Count--;
                }
                else
                {
                    _context.BasketItems.Remove(basketItem);
                }
            }
            TempData["Succeed"] = "Your item is successfully removed from the cart";
            _context.SaveChanges();
            return RedirectToAction("detail", new { id = meal.RestaurantId });
        }

        public IActionResult AddWishlist(int id)
        {
            AppUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            if (user == null) return NotFound();
            Restaurant restaurant = _context.Restaurants.Where(x => !x.IsDeleted).Include(x=>x.Favourites).FirstOrDefault(x => x.Id == id);
            if (restaurant == null) return NotFound();
            if (restaurant.Favourites.Any(x => x.AppUserId == user.Id))
            {
                _context.Favourites.Remove(_context.Favourites.FirstOrDefault(x=>x.RestaurantId==restaurant.Id && x.AppUserId==user.Id));
                _context.SaveChanges();
                TempData["Succeed"] = "Restaurant removed from your wishlist!";
                return RedirectToAction("detail", "restaurant", new { id = restaurant.Id });
            }
            Favourite favourite = new Favourite
            {
                RestaurantId = restaurant.Id,
                AppUserId = user.Id
            };
            if(user.Favourites == null)
            {
                user.Favourites = new List<Favourite>();
            }
            user.Favourites.Add(favourite);
            _context.SaveChanges();
            TempData["Succeed"] = "Restaurant added to your wishlist!";
            return RedirectToAction("detail", "restaurant", new { id = restaurant.Id });
        }

        public IActionResult SetCookie(int id)
        {
            Restaurant restaurant = _context.Restaurants.Where(x => !x.IsDeleted).FirstOrDefault(x => x.Id == id);
            if (restaurant == null) return NotFound();

            var cookieRestaurants = HttpContext.Request.Cookies["Wishlist"];

            if (cookieRestaurants == null)
            {
                List<Restaurant> restaurants = new List<Restaurant>();
                restaurants.Add(restaurant);
                var wishlistStr = JsonConvert.SerializeObject(restaurants);
                HttpContext.Response.Cookies.Append("Wishlist", wishlistStr);
            }
            else
            {
                List<Restaurant> restaurants = JsonConvert.DeserializeObject<List<Restaurant>>(cookieRestaurants);
                if (restaurants.Exists(x=>x.Id==restaurant.Id))
                {
                    restaurants.Remove(restaurants.FirstOrDefault(x=>x.Id==restaurant.Id));
                    var str = JsonConvert.SerializeObject(restaurants);
                    HttpContext.Response.Cookies.Append("Wishlist", str);
                    TempData["Succeed"] = "Restaurant removed from your wishlist!";
                    return RedirectToAction("detail", "restaurant", new { id = restaurant.Id });
                }
                restaurants.Add(restaurant);
                var wishlistStr = JsonConvert.SerializeObject(restaurants);
                HttpContext.Response.Cookies.Append("Wishlist", wishlistStr);
            }
            TempData["Succeed"] = "Restaurant added to your wishlist!";
            return RedirectToAction("detail", "restaurant", new { id = restaurant.Id});
        }

        public IActionResult LoadComments(int restaurantId, int page = 1)
        {
            if (!_context.Restaurants.Any(x => !x.IsDeleted && x.Id == restaurantId)) return Json(new { status = 404 });
            List<Comment> comments = _context.Comments.OrderByDescending(x => x.CreatedAt).Include(x => x.AppUser).Include(x=>x.CommentRates).Where(x => x.RestaurantId == restaurantId && x.Status == true).Take(2 * page).ToList();
            return PartialView("_Comments", comments);
        }

    }
}
