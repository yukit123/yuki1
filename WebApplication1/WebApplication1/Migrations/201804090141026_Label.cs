namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Label : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Labels",
                c => new
                    {
                        LabelId = c.Int(nullable: false, identity: true),
                        LabelName = c.String(),
                    })
                .PrimaryKey(t => t.LabelId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Labels");
        }
    }
}
