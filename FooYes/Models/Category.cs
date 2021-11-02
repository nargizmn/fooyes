using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Image { get; set; }
        public bool IsTrending { get; set; }
        public bool IsPopular { get; set; }
        public bool IsDeleted { get; set; }


        [NotMapped]
        public IFormFile ImageFile { get; set; }

        public List<Restaurant> Restaurants { get; set; }
    }
}
