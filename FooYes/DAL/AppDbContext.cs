using FooYes.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes.DAL
{
    public class AppDbContext:IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
                
        }

        public DbSet<OrderFeature> OrderFeatures { get; set; }
        public DbSet<JobFeature> JobFeatures { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<EmailSubscriber> EmailSubscribers { get; set; }
        public DbSet<ContactCard> ContactCards { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<RestaurantImage> RestaurantImages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<MealSize> MealSizes { get; set; }
        public DbSet<MealType> MealTypes { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Rider> Riders { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CommentRate> CommentRates { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
    }
}
