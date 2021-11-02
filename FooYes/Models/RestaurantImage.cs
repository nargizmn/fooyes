using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes.Models
{
    public class RestaurantImage
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public bool IsMainImage { get; set; }
        public int RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }
    }
}
