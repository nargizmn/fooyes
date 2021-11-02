using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes.ViewModels
{
    public class UserUpdateViewModel
    {
        [StringLength(maximumLength: 25)]
        public string Name { get; set; }
        [StringLength(maximumLength: 25)]
        public string LastName { get; set; }
        public string Image { get; set; }
        [StringLength(maximumLength: 25)]
        [Required]
        public string Username { get; set; }
        [StringLength(maximumLength: 100)]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
        [StringLength(maximumLength: 20)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [StringLength(maximumLength: 20)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [StringLength(maximumLength: 20)]
        [DataType(DataType.Password)]
        [Required]
        public string CurrentPassword { get; set; }
    }
}
