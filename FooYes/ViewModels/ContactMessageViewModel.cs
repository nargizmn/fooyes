using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes.ViewModels
{
    public class ContactMessageViewModel
    {
        [StringLength(maximumLength: 300)]
        [Required]
        public string Message { get; set; }
        [StringLength(maximumLength: 100)]
        public string Email { get; set; }
        [StringLength(maximumLength: 50)]
        public string Name { get; set; }
    }
}
