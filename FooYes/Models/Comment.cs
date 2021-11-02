using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        [Required]
        public string AppUserId { get; set; }
        [StringLength(maximumLength: 50)]
        public string Title { get; set; }

        [StringLength(maximumLength: 250)]
        public string Text { get; set; }
        [Required]
        [Range(1, 10)]
        public double Rate { get; set; }
        public int Useful { get; set; }
        public int NotUseful { get; set; }
        public bool? Status { get; set; }
        public DateTime CreatedAt { get; set; }
        [StringLength(maximumLength: 300)]
        public string AdminNote { get; set; }
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

        public Restaurant Restaurant { get; set; }
        public AppUser AppUser { get; set; }
        public List<CommentRate> CommentRates { get; set; }
    }
}
