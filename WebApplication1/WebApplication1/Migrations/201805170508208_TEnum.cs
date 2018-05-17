namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TEnum : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                 "dbo.TEnums",
                 c => new
                 {
                     EnumId = c.Int(nullable: false, identity: true),
                     EnumType = c.Int(nullable: false),
                     EnumName = c.String(),
                 })
                 .PrimaryKey(t => t.EnumId);
        }
        
        public override void Down()
        {
            DropTable("dbo.TEnums");
        }
    }
}
