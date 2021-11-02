using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes.Models
{
    public class Meal
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:100)]
        public string Name { get; set; }
        [StringLength(maximumLength: 70)]
        public string Ingridients { get; set; }
        public string Image { get; set; }
        [Required]
        public double Price { get; set; }
        public double? DiscountedPrice { get; set; }
        [Required]
        public int RestaurantId { get; set; }
        [Required]
        public int MealTypeId { get; set; }
        public bool IsDeleted { get; set; }

        [NotMapped]
        public List<double> MealSizeExtraCharge { get; set; }
        [NotMapped]
        public List<string> MealSizeName { get; set; }
        [NotMapped]
        public string MealTypeName { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public Restaurant Restaurant { get; set; }
        public MealType MealType { get; set; }
        public List<MealSize> MealSizes { get; set; }
        public List<BasketItem> BasketItems { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
