using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes.Areas.Manage.ViewModels
{
    public class SendEmailViewModel
    {
        [Required]
        [StringLength(maximumLength:20)]
        public string Subject { get; set; }
        [Required]
        [StringLength(maximumLength: 20)]
        public string Header { get; set; }
        [Required]
        [StringLength(maximumLength: 500)]
        public string Text { get; set; }
    }
}
