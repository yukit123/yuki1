namespace TestApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class author2book21 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.author2",
                c => new
                    {
                        Author_id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Author_id);
            
            CreateTable(
                "dbo.book2",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Publisher = c.String(),
                        Author_id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.author2", t => t.Author_id, cascadeDelete: true)
                .Index(t => t.Author_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.book2", "Author_id", "dbo.author2");
            DropIndex("dbo.book2", new[] { "Author_id" });
            DropTable("dbo.book2");
            DropTable("dbo.author2");
        }
    }
}
