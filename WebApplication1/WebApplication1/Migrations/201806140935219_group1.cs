namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class group1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GroupProperties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        GrpId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.GrpId, cascadeDelete: true)
                .Index(t => t.GrpId);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GrpId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.GrpId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GroupProperties", "GrpId", "dbo.Groups");
            DropIndex("dbo.GroupProperties", new[] { "GrpId" });
            DropTable("dbo.Groups");
            DropTable("dbo.GroupProperties");
        }
    }
}
