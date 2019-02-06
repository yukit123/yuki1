namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectAndStudentModelsremote1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VStudents", "Username", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VStudents", "Username");
        }
    }
}
