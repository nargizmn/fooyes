using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes.Models
{
    public class CommentRate
    {
        public int Id { get; set; }
        public int CommentId { get; set; }
        public string AppUserId { get; set; }
        public bool IsUseful { get; set; }

        public Comment Comment { get; set; }
        public AppUser AppUser { get; set; }
    }
}
