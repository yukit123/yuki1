namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Lable2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Labels", "Label_LabelId", "dbo.Labels");
            DropIndex("dbo.Labels", new[] { "Label_LabelId" });
            DropColumn("dbo.Labels", "Label_LabelId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Labels", "Label_LabelId", c => c.Int());
            CreateIndex("dbo.Labels", "Label_LabelId");
            AddForeignKey("dbo.Labels", "Label_LabelId", "dbo.Labels", "LabelId");
        }
    }
}
