using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes.Models
{
    public class Size
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:25)]
        public string Name { get; set; }
        [Required]
        public double ExtraCharge { get; set; }

        public List<MealSize> MealSizes { get; set; }
        public List<BasketItem> BasketItems { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
