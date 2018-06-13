namespace TestApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RMA_History1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RMA_History",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Kundenummer = c.String(),
                        Ordrenummer = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RMA_History");
        }
    }
}
