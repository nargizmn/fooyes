using FooYes.DAL;
using FooYes.Helpers;
using FooYes.Models;
using GodDamnEduHome.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "SuperAdmin, Admin, Editor")]
    public class RestaurantController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IEmailService _emailService;

        public RestaurantController(AppDbContext context, IWebHostEnvironment env, IEmailService emailService)
        {
            _context = context;
            _env = env;
            _emailService = emailService;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.SelectedPage = page;
            double totalPage = _context.Restaurants.Where(x => !x.IsDeleted).Count() / 10d;
            ViewBag.TotalPage = Math.Ceiling(totalPage);
            List<Restaurant> restaurants = _context.Restaurants.Where(x => !x.IsDeleted).Include(x=>x.Category).Include(x=>x.Campaign).Include(x=>x.Comments).OrderByDescending(x => x.Id).Skip((page - 1) * 10).Take(10).ToList();
            return View(restaurants);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _context.Categories.Where(x => !x.IsDeleted).ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Restaurant restaurant)
        {
            ViewBag.Categories = _context.Categories.Where(x => !x.IsDeleted).ToList();
            if (!ModelState.IsValid) return NotFound();
            if (!_context.Categories.Any(x => !x.IsDeleted && x.Id == restaurant.CategoryId))
            {
                ModelState.AddModelError("CategoryId", "Seçdiyiniz kateqoriya mövcud deyildir!");
                return View();
            }
            if(restaurant.HasDelivery==false && restaurant.HasTakeAway == false)
            {
                ModelState.AddModelError("HasDelivery", "Siz restoranın çatdırılma növü barədə seçim etməmisiniz!");
                return View();
            }
            if (restaurant.MainImage == null)
            {
                ModelState.AddModelError("MainImage", "Fayl boş buraxıla bilməz!");
                return View();
            }
            else
            {
                if (restaurant.MainImage.ContentType != "image/jpeg" && restaurant.MainImage.ContentType != "image/png")
                {
                    ModelState.AddModelError("MainImage", "Fayl-ın növü yalnız .jpg və ya .png ola bilər!");
                    return View();
                }

                if (restaurant.MainImage.Length > 2097152)
                {
                    ModelState.AddModelError("MainImage", "Fayl-ın ölcüsü 2MB-dan böyük ola bilməz!");
                    return View();
                }
            }
            if (restaurant.Images != null)
            {
                foreach (var item in restaurant.Images)
                {
                    if (item.ContentType != "image/jpeg" && item.ContentType != "image/png")
                    {
                        ModelState.AddModelError("Images", "Fayl-ın növü yalnız .jpg və ya .png ola bilər!");
                        return View();
                    }

                    if (item.Length > 2097152)
                    {
                        ModelState.AddModelError("Images", "Fayl-ın ölcüsü 2MB-dan böyük ola bilməz!");
                        return View();
                    }
                }
            }
            restaurant.RestaurantImages = new List<RestaurantImage>();

            RestaurantImage mainImage = new RestaurantImage
            {
                IsMainImage = true,
                Image = FileManager.Save(_env.WebRootPath, "uploads/restaurants", restaurant.MainImage)
            };
            restaurant.RestaurantImages.Add(mainImage);

            if (restaurant.Images != null)
            {
                foreach (var item in restaurant.Images)
                {
                    RestaurantImage image = new RestaurantImage
                    {
                        IsMainImage = false,
                        Image = FileManager.Save(_env.WebRootPath, "uploads/restaurants", item)
                    };
                    restaurant.RestaurantImages.Add(image);
                }
            }
            _context.Restaurants.Add(restaurant);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            Restaurant restaurant = _context.Restaurants.FirstOrDefault(x => !x.IsDeleted && x.Id == id);
            if (restaurant == null) return NotFound();
            ViewBag.Categories = _context.Categories.Where(x => !x.IsDeleted).ToList();
            ViewBag.Campaigns = _context.Campaigns.Where(x => !x.IsDeleted && x.ExpireDate >= DateTime.Now).ToList();
            ViewBag.Images = _context.RestaurantImages.Where(x => x.RestaurantId == id).ToList();
            return View(restaurant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Restaurant restaurant)
        {
            ViewBag.Categories = _context.Categories.Where(x => !x.IsDeleted).ToList();
            ViewBag.Campaigns = _context.Campaigns.Where(x => !x.IsDeleted && x.ExpireDate >= DateTime.Now).ToList();
            ViewBag.Images = _context.RestaurantImages.Where(x => x.RestaurantId == restaurant.Id).ToList();
            if (!ModelState.IsValid) return View();
            Restaurant existRestaurant = _context.Restaurants.Include(x => x.RestaurantImages).Include(x => x.Meals).Include(x => x.Campaign).FirstOrDefault(x => !x.IsDeleted && x.Id == restaurant.Id);
            if (existRestaurant == null) return NotFound();
            if (!_context.Categories.Any(x => !x.IsDeleted && x.Id == restaurant.CategoryId))
            {
                ModelState.AddModelError("CategoryId", "Seçdiyiniz kateqoriya mövcud deyildir!");
                return View();
            }
            if (restaurant.CampaignId!=null && !_context.Campaigns.Any(x => !x.IsDeleted && x.Id == restaurant.CampaignId))
            {
                ModelState.AddModelError("CampaignId", "Seçdiyiniz kampaniya mövcud deyildir!");
                return View();
            }
            if (restaurant.HasDelivery == false && restaurant.HasTakeAway == false)
            {
                ModelState.AddModelError("HasDelivery", "Siz restoranın çatdırılma növü barədə seçim etməmisiniz!");
                return View();
            }
            if (restaurant.MainImage!=null)
            {
                if (restaurant.MainImage.ContentType != "image/jpeg" && restaurant.MainImage.ContentType != "image/png")
                {
                    ModelState.AddModelError("MainImage", "Fayl-ın növü yalnız .jpg və ya .png ola bilər!");
                    return View();
                }

                if (restaurant.MainImage.Length > 2097152)
                {
                    ModelState.AddModelError("MainImage", "Fayl-ın ölcüsü 2MB-dan böyük ola bilməz!");
                    return View();
                }
            }
            if (restaurant.Images != null)
            {
                foreach (var item in restaurant.Images)
                {
                    if (item.ContentType != "image/jpeg" && item.ContentType != "image/png")
                    {
                        ModelState.AddModelError("Images", "Fayl-ın növü yalnız .jpg və ya .png ola bilər!");
                        return View();
                    }

                    if (item.Length > 2097152)
                    {
                        ModelState.AddModelError("Images", "Fayl-ın ölcüsü 2MB-dan böyük ola bilməz!");
                        return View();
                    }
                }
            }
            existRestaurant.Name = restaurant.Name;
            existRestaurant.Address = restaurant.Address;
            existRestaurant.CategoryId = restaurant.CategoryId;
            existRestaurant.CampaignId = restaurant.CampaignId;
            existRestaurant.DeliveryFee = restaurant.DeliveryFee;
            existRestaurant.HasDelivery = restaurant.HasDelivery;
            existRestaurant.HasTakeAway = restaurant.HasDelivery;
            existRestaurant.IsRecommended = restaurant.IsRecommended;

            if (restaurant.MainImage != null)
            {
                string filename = FileManager.Save(_env.WebRootPath, "uploads/restaurants", restaurant.MainImage);

                RestaurantImage oldImage = existRestaurant.RestaurantImages.FirstOrDefault(x => x.IsMainImage == true);

                if (oldImage != null)
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/restaurants", oldImage.Image);
                    oldImage.Image = filename;
                }
                else
                {
                    oldImage = new RestaurantImage
                    {
                        Image = filename,
                        IsMainImage = true
                    };
                    existRestaurant.RestaurantImages.Add(oldImage);
                }
            }

            existRestaurant.RestaurantImages.RemoveAll(x => x.IsMainImage != true && !restaurant.ImageIds.Contains(x.Id));

            if (restaurant.Images != null)
            {
                foreach (var item in restaurant.Images)
                {
                    RestaurantImage image = new RestaurantImage
                    {
                        IsMainImage = false,
                        Image = FileManager.Save(_env.WebRootPath, "uploads/restaurants", item)
                    };
                    existRestaurant.RestaurantImages.Add(image);
                }
            }
            if (restaurant.CampaignId != null)
            {
                List<Meal> meals = existRestaurant.Meals.ToList();
                Campaign campaign = _context.Campaigns.FirstOrDefault(x => !x.IsDeleted && x.Id == restaurant.CampaignId);
                foreach (var item in meals)
                {
                    item.DiscountedPrice = Math.Round(item.Price - (item.Price * campaign.DiscountPercent / 100), 1);
                }
            }
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            Restaurant existRestaurant = _context.Restaurants.Include(x=>x.RestaurantImages).FirstOrDefault(x => x.Id == id);
            if (existRestaurant == null)
            {
                return Json(new { status = 404 });
            }
            foreach (var item in existRestaurant.RestaurantImages)
            {
                FileManager.Delete(_env.WebRootPath, "uploads/restaurants", item.Image);
            }
            existRestaurant.IsDeleted = true;
            _context.SaveChanges();

            return Json(new { status = 200 });
        }

        public IActionResult ShowMenu(int id)
        {
            Restaurant restaurant = _context.Restaurants.Include(x => x.Meals).ThenInclude(x => x.MealType).FirstOrDefault(x => !x.IsDeleted && x.Id == id);
            if (restaurant == null) return NotFound();
            return View(restaurant);
        }

        public IActionResult AddMeal(int restaurantId)
        {
            ViewBag.Restaurant = _context.Restaurants.FirstOrDefault(x => !x.IsDeleted && x.Id == restaurantId);
            ViewBag.MealTypes = _context.MealTypes.Where(x => !x.IsDeleted).ToList();
            ViewBag.MealSizes = _context.MealSizes.Include(x=>x.Size).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddMeal(Meal meal, int restaurantId)
        {
            Restaurant restaurant = _context.Restaurants.Include(x=>x.Campaign).FirstOrDefault(x => !x.IsDeleted && x.Id == restaurantId);
            if (restaurant == null) return NotFound();
            ViewBag.Restaurant = restaurant;
            ViewBag.MealTypes = _context.MealTypes.Where(x => !x.IsDeleted).ToList();
            ViewBag.MealSizes = _context.MealSizes.Include(x => x.Size).ToList();
            if (!ModelState.IsValid) return NotFound();
            if(restaurant.Campaign!=null && !restaurant.Campaign.IsDeleted && restaurant.Campaign.ExpireDate >= DateTime.Now)
            {
                meal.DiscountedPrice = meal.Price * meal.Restaurant.Campaign.DiscountPercent / 100;
            }
            else
            {
                meal.DiscountedPrice = meal.Price;
            }        
            if (meal.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Fayl boş buraxıla bilməz!");
                return View();
            }
            else
            {
                if (meal.ImageFile.ContentType != "image/jpeg" && meal.ImageFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("ImageFile", "Fayl-ın növü yalnız .jpg və ya .png ola bilər!");
                    return View();
                }

                if (meal.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "Fayl-ın ölcüsü 2MB-dan böyük ola bilməz!");
                    return View();
                }

                meal.Image = FileManager.Save(_env.WebRootPath, "uploads/meals", meal.ImageFile);
            }
            if (meal.MealTypeName != null)
            {
                MealType mealType = new MealType
                {
                    Name = meal.MealTypeName
                };
                meal.MealType = mealType;
            }
            meal.MealSizes = new List<MealSize>();
            if(meal.MealSizeName !=null && meal.MealSizeExtraCharge!=null)
            {
                int index = 0;
                foreach (var item in meal.MealSizeName)
                {
                    Size size = new Size
                    {
                        Name = item,
                        ExtraCharge = meal.MealSizeExtraCharge[index]
                    };
                    MealSize mealSize = new MealSize
                    {
                        Size = size
                    };
                    meal.MealSizes.Add(mealSize);
                    index++;
                }
            }
            _context.Meals.Add(meal);
            _context.SaveChanges();
            return RedirectToAction("showmenu", new { id = restaurantId });
        }

        public IActionResult EditMeal(int id)
        {
            ViewBag.MealTypes = _context.MealTypes.Where(x => !x.IsDeleted).ToList();
            if (!ModelState.IsValid) return View();
            Meal meal = _context.Meals.Include(x => x.MealSizes).ThenInclude(x => x.Size).FirstOrDefault(x =>!x.IsDeleted && x.Id == id);
            if (meal == null) return NotFound();
            return View(meal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditMeal(Meal meal)
        {
            ViewBag.MealTypes = _context.MealTypes.Where(x => !x.IsDeleted).ToList();
            if (!ModelState.IsValid) return View(meal);
            Meal existMeal = _context.Meals.Include(x => x.MealSizes).ThenInclude(x => x.Size).FirstOrDefault(x =>!x.IsDeleted && x.Id == meal.Id);
            if (existMeal == null) return NotFound();
            if (meal.ImageFile != null)
            {
                if (meal.ImageFile.ContentType != "image/jpeg" && meal.ImageFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("ImageFile", "Fayl-ın növü yalnız .jpg və ya .png ola bilər!");
                    return View();
                }

                if (meal.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "Fayl-ın ölcüsü 2MB-dan böyük ola bilməz!");
                    return View();
                }

                string fileName = FileManager.Save(_env.WebRootPath, "uploads/meals", meal.ImageFile);
                if (existMeal.Image != null)
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/meals", existMeal.Image);
                }
                existMeal.Image = fileName;
            }

            existMeal.Name = meal.Name;
            existMeal.Price = meal.Price;
            existMeal.Ingridients = meal.Ingridients;
            if (meal.MealTypeName != null)
            {
                MealType mealType = new MealType
                {
                    Name = meal.MealTypeName
                };
                existMeal.MealType = mealType;
            }
            else
            {
                existMeal.MealTypeId = meal.MealTypeId;
            }
            if (existMeal.MealSizes != null)
            {
                foreach (var item in existMeal.MealSizes.Select(x => x.SizeId))
                {
                    Size size = _context.Sizes.FirstOrDefault(x => x.Id == item);
                    _context.Sizes.Remove(size);
                }
                existMeal.MealSizes.RemoveAll(x => x.MealId == existMeal.Id);
            }
            if (meal.MealSizeName != null && meal.MealSizeExtraCharge != null)
            {
                existMeal.MealSizes = new List<MealSize>();
                int index = 0;
                foreach (var item in meal.MealSizeName)
                {
                    Size size = new Size
                    {
                        Name = item,
                        ExtraCharge = meal.MealSizeExtraCharge[index]
                    };
                    MealSize mealSize = new MealSize
                    {
                        Size = size
                    };
                    existMeal.MealSizes.Add(mealSize);
                    index++;
                }
            }
            _context.SaveChanges();
            return RedirectToAction("showmenu", new { id=existMeal.RestaurantId });
        }

        public IActionResult DeleteMeal(int id)
        {
            Meal existMeal = _context.Meals.FirstOrDefault(x => !x.IsDeleted && x.Id == id);
            if (existMeal == null)
            {
                return Json(new { status = 404 });
            }
            if (existMeal.Image != null)
            {
                FileManager.Delete(_env.WebRootPath, "uploads/meals", existMeal.Image);
            }
            existMeal.IsDeleted = true;
            _context.SaveChanges();

            return Json(new { status = 200 });
        }

        public IActionResult SeeComments(int restaurantId, int page = 1)
        {
            ViewBag.SelectedPage = page;
            double totalPage = _context.Comments.Where(x => x.RestaurantId == restaurantId).Count() / 3d;
            ViewBag.TotalPage = Math.Ceiling(totalPage);
            if (!_context.Restaurants.Any(x => !x.IsDeleted && x.Id == restaurantId)) return NotFound();
            Restaurant restaurant = _context.Restaurants.FirstOrDefault(x => !x.IsDeleted && x.Id == restaurantId);
            if (restaurant == null) return NotFound();
            ViewBag.Restaurant = restaurant;
            List<Comment> comments = _context.Comments.OrderByDescending(x => x.CreatedAt).Include(x => x.AppUser).Where(x => x.RestaurantId == restaurantId).Skip((page - 1) * 3).Take(3).ToList();
            return View(comments);
        }

        public IActionResult CommentDetails(int id)
        {
            Comment comment = _context.Comments.Include(x=>x.Restaurant).Include(x=>x.AppUser).FirstOrDefault(x => x.Id == id);
            if (comment == null) return NotFound();
            return View(comment);
        }

        public IActionResult AcceptComment(int commentId, string note)
        {
            Comment comment = _context.Comments.Include(x => x.AppUser).Include(x=>x.Restaurant).FirstOrDefault(x => x.Id == commentId);
            if (comment == null) return NotFound();
            comment.Status = true;
            comment.AdminNote = note;
            _context.SaveChanges();

            Restaurant restaurant = _context.Restaurants.FirstOrDefault(x => !x.IsDeleted && x.Id == comment.RestaurantId);
            if (restaurant == null) return NotFound();
            List<Comment> acceptedComments = _context.Comments.Where(x => x.Status == true && x.RestaurantId==comment.RestaurantId).ToList();
            restaurant.Rate = acceptedComments.Count() == 0 ? 0 : Math.Round(acceptedComments.Average(x => x.Rate), 1);
            restaurant.PriceRate = acceptedComments.Count() == 0 ? 0 : Math.Round(acceptedComments.Average(x => x.PriceRate), 1);
            restaurant.FoodRate = acceptedComments.Count() == 0 ? 0 : Math.Round(acceptedComments.Average(x => x.FoodRate), 1);
            restaurant.PunctualityRate = acceptedComments.Count() == 0 ? 0 : Math.Round(acceptedComments.Average(x => x.PunctualityRate), 1);
            restaurant.ServiceRate = acceptedComments.Count() == 0 ? 0 : Math.Round(acceptedComments.Average(x => x.ServiceRate), 1);
            _context.SaveChanges();

            string body = string.Empty;
            using (StreamReader reader = new StreamReader("wwwroot/templates/accept.html"))
            {
                body = reader.ReadToEnd();
            }
            string hiddenHeader = "Your review has been accepted! Click to get more information!";
            string textHeader = "Your review has been accepted!";
            string mainText = $"Thank you for reviewing our {comment.Restaurant.Name} restaurant!";
            if (comment.AdminNote != null)
            {
                string adminNote = $@"<h2 style=\""margin-top: 15px;\"">Note : {comment.AdminNote}</h2>";
                mainText += adminNote;
            }
            body = body.Replace("{{hiddenHeader}}", hiddenHeader)
                    .Replace("{{textHeader}}", textHeader)
                    .Replace("{{mainText}}", mainText);
            _emailService.Send(comment.AppUser.Email, "Your review has been accepted!", body);
            return Json(new { status = 200 });
        }

        public IActionResult RejectComment (int commentId, string note)
        {
            Comment comment = _context.Comments.Include(x => x.AppUser).Include(x=>x.Restaurant).FirstOrDefault(x => x.Id == commentId);
            if (comment == null) return Json(new { status = 404 });
            if (string.IsNullOrWhiteSpace(note))
            {
                return Json(new { status = 400 });
            }
            comment.Status = false;
            comment.AdminNote = note;
            _context.SaveChanges();

            Restaurant restaurant = _context.Restaurants.FirstOrDefault(x => !x.IsDeleted && x.Id == comment.RestaurantId);
            List<Comment> acceptedComments = _context.Comments.Where(x => x.Status == true).ToList();
            restaurant.Rate = acceptedComments.Count() == 0 ? 0 : Math.Round(acceptedComments.Average(x => x.Rate));
            restaurant.PriceRate = acceptedComments.Count() == 0 ? 0 : (int)Math.Round(acceptedComments.Average(x => x.PriceRate));
            restaurant.FoodRate = acceptedComments.Count() == 0 ? 0 : (int)Math.Round(acceptedComments.Average(x => x.FoodRate));
            restaurant.PunctualityRate = acceptedComments.Count() == 0 ? 0 : (int)Math.Round(acceptedComments.Average(x => x.PunctualityRate));
            restaurant.ServiceRate = acceptedComments.Count() == 0 ? 0 : (int)Math.Round(acceptedComments.Average(x => x.ServiceRate));
            _context.SaveChanges();

            string body = string.Empty;
            using (StreamReader reader = new StreamReader("wwwroot/templates/reject.html"))
            {
                body = reader.ReadToEnd();
            }
            string hiddenHeader = "Your review has been rejected! Click to get more information!";
            string textHeader = "Your review has been rejected!";
            string mainText = $"We are sorry to announce that your review for {comment.Restaurant.Name} restaurant has been rejected! You can check the details down below.";
            body = body.Replace("{{hiddenHeader}}", hiddenHeader)
                    .Replace("{{textHeader}}", textHeader)
                    .Replace("{{mainText}}", mainText)
                    .Replace("{{AdminNote}}", note);
            _emailService.Send(comment.AppUser.Email, "Your join request has been rejected!", body);
            return Json(new { status = 200 });
        }
    }
}
