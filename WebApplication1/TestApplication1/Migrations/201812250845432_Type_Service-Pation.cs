namespace TestApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Type_ServicePation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PationName = c.String(),
                        Age = c.Int(nullable: false),
                        Sex = c.Int(nullable: false),
                        Type_ServiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Type_Service", t => t.Type_ServiceId, cascadeDelete: true)
                .Index(t => t.Type_ServiceId);
            
            CreateTable(
                "dbo.Type_Service",
                c => new
                    {
                        Type_ServiceId = c.Int(nullable: false, identity: true),
                        NameService = c.String(),
                    })
                .PrimaryKey(t => t.Type_ServiceId);
            
            AlterColumn("dbo.AuthorModels", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pations", "Type_ServiceId", "dbo.Type_Service");
            DropIndex("dbo.Pations", new[] { "Type_ServiceId" });
            AlterColumn("dbo.AuthorModels", "Name", c => c.String());
            DropTable("dbo.Type_Service");
            DropTable("dbo.Pations");
        }
    }
}
