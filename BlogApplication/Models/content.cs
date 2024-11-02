using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rating.Models
{
    public class content
    {
        [Key]
        public Guid postId { get; set; }
        public Guid authorId { get; set; }
        public string title { get; set; }
        public int rating { get; set; }
        public string source { get; set; }
    }
}