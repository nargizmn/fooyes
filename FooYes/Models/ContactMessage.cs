using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes.Models
{
    public class ContactMessage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string AppUserId { get; set; }
        [StringLength(maximumLength: 300)]
        [Required]
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
        [Required]
        public bool IsUser { get; set; }

        public AppUser AppUser { get; set; }
    }
}
