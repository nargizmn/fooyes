using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes.Models
{
    public class Rider
    {
        public int Id { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string VehicleType { get; set; }
        [Required]
        [StringLength(maximumLength:50)]
        public string Fullname { get; set; }
        public string JobSource { get; set; }
        [Required]
        [StringLength(maximumLength:25)]
        public string Email { get; set; }
        [Required]
        [StringLength(maximumLength:13)]
        public string Telephone { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public bool TermsAccept { get; set; }
        public bool? Status { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        [StringLength(maximumLength: 300)]
        public string AdminNote { get; set; }

        public List<Order> Orders { get; set; }
    }
}
