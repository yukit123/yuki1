namespace TestApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Chartersorderby1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Charters", "CharterDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Charters", "CharterDate", c => c.DateTime());
        }
    }
}
