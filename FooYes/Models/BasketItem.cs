using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes.Models
{
    public class BasketItem
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public int MealId { get; set; }
        public int Count { get; set; }
        public int? SizeId { get; set; }

        public AppUser AppUser { get; set; }
        public Meal Meal { get; set; }
        public Size Size { get; set; }
    }
}
