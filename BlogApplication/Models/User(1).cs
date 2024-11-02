using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogApplication.Models
{
    public class User
    {
        public Guid userId { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public bool isAdmin { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
    }
}