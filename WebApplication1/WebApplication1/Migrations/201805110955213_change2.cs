namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.le_leaveApplication", "LeaveDurationDays", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.le_leaveApplication", "LeaveDurationDays", c => c.Int(nullable: false));
        }
    }
}
