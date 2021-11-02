using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes.ViewModels
{
    public class UserLoginViewModel
    {
        [StringLength(maximumLength: 20)]
        [Required]
        public string Username { get; set; }
        [StringLength(maximumLength: 20)]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
    }
}
