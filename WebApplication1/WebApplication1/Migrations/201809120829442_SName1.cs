namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SName1 : DbMigration
    {
        public override void Up()//how to merge rows with same id
        {
            CreateTable(
                "dbo.SNames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ids = c.Int(nullable: false),
                        name1 = c.String(),
                        name2 = c.String(),
                        name3 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SNames");
        }
    }
}
