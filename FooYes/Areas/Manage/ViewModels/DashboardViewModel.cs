using FooYes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes.Areas.Manage.ViewModels
{
    public class DashboardViewModel
    {
        public List<Order> Orders { get; set; }
        public List<Rider> RiderRequests { get; set; }
        public List<ContactMessage> NewContactMessages { get; set; }
        public List<Comment> CommentRequests { get; set; }
        public List<EmailSubscriber> Subscribers { get; set; }
        public List<Restaurant> MostOrderedRestaurants { get; set; }
    }
}
