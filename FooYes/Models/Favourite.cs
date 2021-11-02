using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes.Models
{
    public class Favourite
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public string AppUserId { get; set; }

        public Restaurant Restaurant { get; set; }
        public AppUser AppUser { get; set; }
    }
}
