using FooYes.DAL;
using FooYes.Models;
using FooYes.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes.Services
{
    public class LayoutService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LayoutService(AppDbContext context, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public Setting GetSetting()
        {
            return _context.Settings.FirstOrDefault();
        }


        public BasketViewModel GetBasket()
        {
            BasketViewModel basketData = new BasketViewModel
            {
                BasketItems = new List<BasketItemViewModel>(),
                TotalPrice = 0
            };

            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated && _userManager.Users.Any(x => x.UserName == _httpContextAccessor.HttpContext.User.Identity.Name && x.IsAdmin == false))
            {
                var basketItems = _context.BasketItems.Include(x=>x.Size).Include(x => x.AppUser).Include(x => x.Meal).ThenInclude(x=>x.Restaurant).ThenInclude(x=>x.Campaign).Where(x => x.AppUser.UserName == _httpContextAccessor.HttpContext.User.Identity.Name);

                foreach (var item in basketItems)
                {
                    BasketItemViewModel basketItemVM = new BasketItemViewModel
                    {
                        Meal = item.Meal,
                        Count = item.Count,
                        Size = item.Size
                    };

                    basketData.BasketItems.Add(basketItemVM);
                    basketData.Count++;
                }
            }
            return basketData;
        }
    }
}
