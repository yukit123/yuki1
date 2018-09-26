namespace TestApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentAccounts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentAccounts",
                c => new
                    {
                        Userid = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Userid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StudentAccounts");
        }
    }
}
