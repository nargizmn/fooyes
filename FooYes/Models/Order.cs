using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
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
        [StringLength(maximumLength: 300)]
        public string AdminNote { get; set; }
        public DateTime CreatedAt { get; set; }
        public string DeliveryDate { get; set; }
        public string DeliveryTime { get; set; }
        public string DeliveryType { get; set; }
        public double TotalPrice { get; set; }
        public bool? Status { get; set; }
        public int? RiderId { get; set; }

        public AppUser AppUser { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public Rider Rider { get; set; }
    }
}
