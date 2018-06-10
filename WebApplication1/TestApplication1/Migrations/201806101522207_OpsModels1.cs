namespace TestApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OpsModels1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OpsModels",
                c => new
                    {
                        OrderNumber = c.Int(nullable: false, identity: true),
                        EmailSubject = c.String(),
                        EMailBody = c.String(),
                        ToEmail = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.OrderNumber);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OpsModels");
        }
    }
}
