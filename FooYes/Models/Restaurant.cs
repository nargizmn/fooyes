using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [StringLength(maximumLength:100)]
        public string Address { get; set; }
        public double? Rate { get; set; }
        public double? FoodRate { get; set; }
        public double? ServiceRate { get; set; }
        public double? PunctualityRate { get; set; }
        public double? PriceRate { get; set; }
        public bool HasDelivery { get; set; }
        public bool HasTakeAway { get; set; }
        public bool IsRecommended { get; set; }
        public double DeliveryFee { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public int? CampaignId { get; set; }
        public bool IsDeleted { get; set; }

        [NotMapped]
        public IFormFile MainImage { get; set; }
        [NotMapped]
        public List<IFormFile> Images { get; set; }
        [NotMapped]
        public List<int> ImageIds { get; set; }
        public Campaign Campaign { get; set; }
        public Category Category { get; set; }
        public List<RestaurantImage> RestaurantImages { get; set; }
        public List<Meal> Meals { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Favourite> Favourites { get; set; }
    }
}
