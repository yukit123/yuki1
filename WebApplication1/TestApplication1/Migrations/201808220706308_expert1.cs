namespace TestApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class expert1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.experts",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        first_name = c.String(nullable: false, maxLength: 50),
                        last_name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.experts");
        }
    }
}
