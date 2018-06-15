namespace TestApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class group1 : DbMigration
    {
        //public override void Up()
        //{
        //    DropForeignKey("dbo.GroupProperties", "Group_GrpId", "dbo.Groups");
        //    DropIndex("dbo.GroupProperties", new[] { "Group_GrpId" });
        //    RenameColumn(table: "dbo.GroupProperties", name: "Group_GrpId", newName: "GrpId");
        //    AlterColumn("dbo.GroupProperties", "GrpId", c => c.Int(nullable: false));
        //    CreateIndex("dbo.GroupProperties", "GrpId");
        //    AddForeignKey("dbo.GroupProperties", "GrpId", "dbo.Groups", "GrpId", cascadeDelete: true);
        //}

        //public override void Down()
        //{
        //    DropForeignKey("dbo.GroupProperties", "GrpId", "dbo.Groups");
        //    DropIndex("dbo.GroupProperties", new[] { "GrpId" });
        //    AlterColumn("dbo.GroupProperties", "GrpId", c => c.Int());
        //    RenameColumn(table: "dbo.GroupProperties", name: "GrpId", newName: "Group_GrpId");
        //    CreateIndex("dbo.GroupProperties", "Group_GrpId");
        //    AddForeignKey("dbo.GroupProperties", "Group_GrpId", "dbo.Groups", "GrpId");
        //}

        public override void Up()
        {
            CreateTable(
                "dbo.GroupProperties",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Description = c.String(),
                    GrpId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.GrpId, cascadeDelete: true)
                .Index(t => t.GrpId);

            CreateTable(
                "dbo.Groups",
                c => new
                {
                    GrpId = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Description = c.String(),
                })
                .PrimaryKey(t => t.GrpId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.GroupProperties", "GrpId", "dbo.Groups");
            DropIndex("dbo.GroupProperties", new[] { "GrpId" });
            DropTable("dbo.Groups");
            DropTable("dbo.GroupProperties");
        }
    }
}
