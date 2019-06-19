namespace TestApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class book2Publishergetter2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.book2", "Publisher", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.book2", "Publisher");
        }
    }
}
