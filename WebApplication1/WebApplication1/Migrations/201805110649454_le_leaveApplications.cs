namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class le_leaveApplications : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.le_leaveApplication",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        LeaveType = c.String(),
                        LeaveFrom = c.DateTime(nullable: false),
                        LeaveTo = c.DateTime(nullable: false),
                        LeaveDurationDays = c.Int(nullable: false),
                        DateApplied = c.DateTime(nullable: false),
                        ApplicationStatus = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.le_leaveApplication");
        }
    }
}
