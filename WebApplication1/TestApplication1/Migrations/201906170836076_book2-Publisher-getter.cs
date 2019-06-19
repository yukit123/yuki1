namespace TestApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class book2Publishergetter : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.book2", "Publisher");
        }
        
        public override void Down()
        {
            AddColumn("dbo.book2", "Publisher", c => c.String());
        }
    }
}
