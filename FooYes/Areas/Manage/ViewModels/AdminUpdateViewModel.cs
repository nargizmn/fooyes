using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes.Areas.Manage.ViewModels
{
    public class AdminUpdateViewModel
    {
        [Required]
        [StringLength(maximumLength: 25)]
        public string UserName { get; set; }
        [StringLength(maximumLength: 25)]
        public string Name { get; set; }
        [StringLength(maximumLength: 25)]
        public string LastName { get; set; }
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
        public string IdentityRole { get; set; }
    }
}
