namespace TestApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class charters2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Charters", "CharterDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Charters", "CharterDate");
        }
    }
}
