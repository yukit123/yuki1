namespace TestApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class author2ValidationAttribute1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.author2", "Compare1", c => c.String());
            AddColumn("dbo.author2", "Compare2", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.author2", "Compare2");
            DropColumn("dbo.author2", "Compare1");
        }
    }
}
