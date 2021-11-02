using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes.ViewModels
{
    public class EmailSubscribeViewModel
    {
        [DataType(DataType.EmailAddress)]
        [Required]
        public string MailAddress { get; set; }
    }
}
