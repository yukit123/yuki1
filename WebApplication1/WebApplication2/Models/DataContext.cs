using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class DataContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}