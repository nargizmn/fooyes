using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
        public string Image { get; set; }

        public List<Comment> Comments { get; set; }
        public List<BasketItem> BasketItems { get; set; }
        public List<CommentRate> CommentRates { get; set; }
        public List<Favourite> Favourites { get; set; }
    }
}
