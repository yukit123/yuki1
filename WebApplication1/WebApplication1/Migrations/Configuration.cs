﻿namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication1.Models.BlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;//true 自动生成
        }

        protected override void Seed(WebApplication1.Models.BlogContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Blogs.AddOrUpdate(
                new Models.Blog { BlogId = 1, Name = "a" }
                );
        }
    }
}
