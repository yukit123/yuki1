namespace TestApplication1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TestApplication1.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TestApplication1.Models.TestApplication1Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TestApplication1.Models.TestApplication1Context context)//https://forums.asp.net/t/2146113.aspx
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            //Tool toolHome = new Tool() {Id= new Guid("7178a7fd-51ab-e811-b867-8cec4b594df1"),  Name = "Homes23",  Path = @"App_Data\HomeTool.xlsx" , CreatedOn = DateTime.Now};

            Tool toolHome2 = new Tool() {Id=Guid.NewGuid(),Name = "Homes23", Path = @"App_Data\HomeTool2333.xlsx", CreatedOn = DateTime.Now };

            context.Tools.AddOrUpdate(c => c.Name, toolHome2);

            context.SaveChanges();

        }
    }
}
