namespace TestApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20181122 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RMA_History", "Kundenummer", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RMA_History", "Kundenummer", c => c.String());
        }
    }
}
