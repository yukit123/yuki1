namespace TestApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Student121 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ViewModelAttendanceClients", "TimeManagerSetsMdl_TmeMngrSetKey", "dbo.TimeManagerSetsMdls");
            DropForeignKey("dbo.ViewModelAttendanceClients", "TimeManagerSetsMdl_TmeMngrSetKey1", "dbo.TimeManagerSetsMdls");
            DropForeignKey("dbo.ViewModelAttendanceClients", "TmeMngrSetsMdlObj_TmeMngrSetKey", "dbo.TimeManagerSetsMdls");
            DropIndex("dbo.ViewModelAttendanceClients", new[] { "TimeManagerSetsMdl_TmeMngrSetKey" });
            DropIndex("dbo.ViewModelAttendanceClients", new[] { "TimeManagerSetsMdl_TmeMngrSetKey1" });
            DropIndex("dbo.ViewModelAttendanceClients", new[] { "TmeMngrSetsMdlObj_TmeMngrSetKey" });
            CreateTable(
                "dbo.Student121",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        StudentName = c.String(),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.StudentAddress121",
                c => new
                    {
                        StudentAddressId = c.Int(nullable: false),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.StudentAddressId)
                .ForeignKey("dbo.Student121", t => t.StudentAddressId)
                .Index(t => t.StudentAddressId);
            
            DropTable("dbo.ViewModelAttendanceClients");
            DropTable("dbo.TimeManagerSetsMdls");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TimeManagerSetsMdls",
                c => new
                    {
                        TmeMngrSetKey = c.Int(nullable: false, identity: true),
                        TimeManagerSet = c.String(),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.TmeMngrSetKey);
            
            CreateTable(
                "dbo.ViewModelAttendanceClients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimeManagerSetsMdl_TmeMngrSetKey = c.Int(),
                        TimeManagerSetsMdl_TmeMngrSetKey1 = c.Int(),
                        TmeMngrSetsMdlObj_TmeMngrSetKey = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.StudentAddress121", "StudentAddressId", "dbo.Student121");
            DropIndex("dbo.StudentAddress121", new[] { "StudentAddressId" });
            DropTable("dbo.StudentAddress121");
            DropTable("dbo.Student121");
            CreateIndex("dbo.ViewModelAttendanceClients", "TmeMngrSetsMdlObj_TmeMngrSetKey");
            CreateIndex("dbo.ViewModelAttendanceClients", "TimeManagerSetsMdl_TmeMngrSetKey1");
            CreateIndex("dbo.ViewModelAttendanceClients", "TimeManagerSetsMdl_TmeMngrSetKey");
            AddForeignKey("dbo.ViewModelAttendanceClients", "TmeMngrSetsMdlObj_TmeMngrSetKey", "dbo.TimeManagerSetsMdls", "TmeMngrSetKey");
            AddForeignKey("dbo.ViewModelAttendanceClients", "TimeManagerSetsMdl_TmeMngrSetKey1", "dbo.TimeManagerSetsMdls", "TmeMngrSetKey");
            AddForeignKey("dbo.ViewModelAttendanceClients", "TimeManagerSetsMdl_TmeMngrSetKey", "dbo.TimeManagerSetsMdls", "TmeMngrSetKey");
        }
    }
}
