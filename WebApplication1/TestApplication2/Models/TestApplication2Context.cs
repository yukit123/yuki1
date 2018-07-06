using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestApplication2.Models
{
    public class TestApplication2Context : DbContext
    {
        public DbSet<Test> Tests { get; set; }
    }
}