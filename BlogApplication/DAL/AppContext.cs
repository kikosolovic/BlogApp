using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Rating.Models;

namespace Rating.DAL
{
    public class AppContext:DbContext
    {
        public AppContext() : base("AppContext")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<content> post { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}