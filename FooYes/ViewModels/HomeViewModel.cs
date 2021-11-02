using FooYes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes.ViewModels
{
    public class HomeViewModel
    {
        public List<Restaurant> TopRatedRestaurants { get; set; }
        public List<Category> PopularCategories { get; set; }
        public List<Category> TrendingCategories { get; set; }
        public List<OrderFeature> OrderFeatures { get; set; }
        public List<ContactCard> ContactCards { get; set; }
        public List<Faq> Faqs { get; set; }
        public List<JobFeature> JobFeatures { get; set; }
        public Setting Setting { get; set; }
        public ContactMessageViewModel ContactMessageVM { get; set; }
    }
}
