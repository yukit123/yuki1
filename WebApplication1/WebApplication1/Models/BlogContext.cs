using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class BlogContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Label> Label { get; set; }

        public DbSet<Tree> Tree { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<VStudent> Student { get; set; }

        public DbSet<Column> Column { get; set; }
        public DbSet<Search> Search { get; set; }
        public DbSet<City> Cities { get; set; }




    }
}