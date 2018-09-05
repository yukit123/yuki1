namespace TestApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class automaticmgration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OpsModels", "EMailBody", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OpsModels", "EMailBody", c => c.String());
        }
    }
}
