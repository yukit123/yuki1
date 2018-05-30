namespace TestApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class authormodels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuthorModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        PublishedDate = c.DateTime(nullable: false),
                        AuthorModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AuthorModels", t => t.AuthorModel_Id)
                .Index(t => t.AuthorModel_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "AuthorModel_Id", "dbo.AuthorModels");
            DropIndex("dbo.Books", new[] { "AuthorModel_Id" });
            DropTable("dbo.Books");
            DropTable("dbo.AuthorModels");
        }
    }
}
