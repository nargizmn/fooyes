using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes.Models
{
    public class Campaign
    {
        public int Id { get; set; }
        [Required]
        public double DiscountPercent { get; set; }
        [Required]
        public DateTime ExpireDate { get; set; }
        public bool IsDeleted { get; set; }

        public List<Restaurant> Restaurants { get; set; }
    }
}
