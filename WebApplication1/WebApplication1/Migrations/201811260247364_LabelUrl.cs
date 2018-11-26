namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LabelUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Labels", "url", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Labels", "url");
        }
    }
}
