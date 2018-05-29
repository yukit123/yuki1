namespace TestApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class countrysizes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CountrySizes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        country = c.String(),
                        size = c.String(),
                        value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CountrySizes");
        }
    }
}
