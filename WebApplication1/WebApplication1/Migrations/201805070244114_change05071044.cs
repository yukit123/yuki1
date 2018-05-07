namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change05071044 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
               "dbo.Cities",
               c => new
               {
                   Id = c.Int(nullable: false, identity: true),
                   CountryId = c.String(),
                   CityName = c.String(),
               })
               .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.Cities");
        }
    }
}
