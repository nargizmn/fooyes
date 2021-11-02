using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes.Models
{
    public class ContactCard
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:200)]
        public string Icon { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string Title { get; set; }
        [Required]
        [StringLength(maximumLength: 300)]
        public string Subtitle { get; set; }
        [Required]
        [StringLength(maximumLength: 300)]
        public string WorkingHours{ get; set; }
    }
}
