namespace TestApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class expert2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.experts", "ischeck", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.experts", "ischeck");
        }
    }
}
