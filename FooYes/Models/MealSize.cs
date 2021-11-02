using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes.Models
{
    public class MealSize
    {
        public int Id { get; set; }
        [Required]
        public int MealId { get; set; }
        [Required]
        public int SizeId { get; set; }

        public Meal Meal { get; set; }
        public Size Size { get; set; }
    }
}
