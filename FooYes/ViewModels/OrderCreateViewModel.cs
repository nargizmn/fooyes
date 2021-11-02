using FooYes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes.ViewModels
{
    public class OrderCreateViewModel
    {
        [StringLength(maximumLength: 50)]
        [Required]
        public string Fullname { get; set; }
        [StringLength(maximumLength: 20)]
        [Required]
        public string City { get; set; }
        [StringLength(maximumLength: 200)]
        [Required]
        public string Address { get; set; }
        [StringLength(maximumLength: 20)]
        [Required]
        public string Phone { get; set; }
        [StringLength(maximumLength: 6)]
        [Required]
        public string PostalCode { get; set; } 
        public string DeliveryDate { get; set; }
        public string DeliveryTime { get; set; }
        public string DeliveryType { get; set; }
        public int RestaurantId { get; set; }
        public double SubTotalPrice { get; set; }

        public List<BasketItem> BasketItems { get; set; }
    }
}
