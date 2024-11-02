using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogApplication.Models
{
    public class Blog
    {
        public Guid blogId { get; set; }
        public Guid authorId { get; set; }
        public string title { get; set; }
        public string rating { get; set; }
        public string image { get; set; }
    }
}