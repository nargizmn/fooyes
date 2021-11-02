using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int MealId { get; set; }
        public int? SizeId { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }

        public Meal Meal { get; set; }
        public Order Order { get; set; }
        public Size Size { get; set; }
    }
}
