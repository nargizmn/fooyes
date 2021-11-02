using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes.Areas.Manage.ViewModels
{
    public class AdminCreateViewModel
    {
        [Required]
        [StringLength(maximumLength: 25)]
        public string UserName { get; set; }
        [Required]
        [StringLength(maximumLength: 25)]
        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength: 25)]
        public string LastName { get; set; }
        [Required]
        [StringLength(maximumLength: 20)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [StringLength(maximumLength: 20)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string IdentityRole { get; set; }
    }
}
