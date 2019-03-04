﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class BlogContext : DbContext
    {
        internal readonly IEnumerable<object> Charters;

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Label> Label { get; set; }

        public DbSet<Tree> Tree { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<VStudent> Student { get; set; }

        public DbSet<Column> Column { get; set; }
        public DbSet<Search> Search { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<le_leaveApplication> le_leaveApplications { get; set; }
        public DbSet<TEnum> TEnums { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupProperty> GroupProperties { get; set; }
        public DbSet<SName> SNames { get; set; }

        







    }
}