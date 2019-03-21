namespace TestApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Chartersorderby2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Charters", "CharterDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Charters", "CharterDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
    }
}
