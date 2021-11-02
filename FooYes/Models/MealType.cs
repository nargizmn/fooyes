using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes.Models
{
    public class MealType
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:70)]
        public string Name { get; set; }
        [Required]
        public int Order { get; set; }
        public bool IsDeleted { get; set; }

        public List<Meal> Meals { get; set; }
    }
}
