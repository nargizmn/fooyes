using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes.ViewModels
{
    public class UserRegisterViewModel
    {
        [Required]
        [StringLength(maximumLength: 25)]
        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength: 25)]
        public string LastName { get; set; }
        [Required]
        [StringLength(maximumLength: 20)]
        public string Username { get; set; }
        [StringLength(maximumLength: 100)]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
        [StringLength(maximumLength: 20)]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        [StringLength(maximumLength: 20)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Required]
        public string ConfirmPassword { get; set; }
    }
}
