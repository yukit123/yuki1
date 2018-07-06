namespace TestApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RMA_Historyaddnew2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RMA_History", "NewColum2", c => c.String());
            DropColumn("dbo.RMA_History", "NewColum");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RMA_History", "NewColum", c => c.String());
            DropColumn("dbo.RMA_History", "NewColum2");
        }
    }
}
