using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes.ViewModels
{
    public class CreateCommentViewModel
    {
        public int RestaurantId { get; set; }
        [StringLength(maximumLength: 50)]
        public string Title { get; set; }

        [StringLength(maximumLength: 250)]
        public string Text { get; set; }
        [Required]
        [Range(1, 10)]
        public int FoodRate { get; set; }
        [Required]
        [Range(1, 10)]
        public int ServiceRate { get; set; }
        [Required]
        [Range(1, 10)]
        public int PunctualityRate { get; set; }
        [Required]
        [Range(1, 10)]
        public int PriceRate { get; set; }
    }
}
