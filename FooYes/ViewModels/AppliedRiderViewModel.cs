using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes.ViewModels
{
    public class AppliedRiderViewModel
    {
        [Required]
        public string City { get; set; }
        [Required]
        public string VehicleType { get; set; }
        [Required]
        public List<string> JobSource { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string Fullname { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string Email { get; set; }
        [Required]
        [StringLength(maximumLength: 13)]
        public string Telephone { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public bool TermsAccept { get; set; }
    }
}
