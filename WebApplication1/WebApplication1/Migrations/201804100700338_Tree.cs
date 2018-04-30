namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tree : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Trees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NodeId = c.Int(nullable: false),
                        Name = c.String(),
                        Tree_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trees", t => t.Tree_Id)
                .Index(t => t.Tree_Id);
            
            AddColumn("dbo.Labels", "Label_LabelId", c => c.Int());
            CreateIndex("dbo.Labels", "Label_LabelId");
            AddForeignKey("dbo.Labels", "Label_LabelId", "dbo.Labels", "LabelId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trees", "Tree_Id", "dbo.Trees");
            DropForeignKey("dbo.Labels", "Label_LabelId", "dbo.Labels");
            DropIndex("dbo.Trees", new[] { "Tree_Id" });
            DropIndex("dbo.Labels", new[] { "Label_LabelId" });
            DropColumn("dbo.Labels", "Label_LabelId");
            DropTable("dbo.Trees");
        }
    }
}
