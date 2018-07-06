namespace TestApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RMA_Historyaddnew1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RMA_History", "NewColum", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RMA_History", "NewColum");
        }
    }
}
