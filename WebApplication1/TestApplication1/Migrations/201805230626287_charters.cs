namespace TestApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class charters : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Charters",
                c => new
                    {
                        CharterID = c.Int(nullable: false, identity: true),
                        CharterDesignatorString = c.String(),
                        CharterIdentifier = c.Int(nullable: false),
                        CharterIdentifierString = c.String(),
                        CharterDestinationLocation1 = c.String(),
                        CharterDestinationLocation2 = c.String(),
                        CharterDistanceString = c.String(),
                        CharterSchoolDepartment = c.String(),
                        CharterGroup = c.String(),
                        CharterGroupLevelString = c.String(),
                        CharterGroupGenderString = c.String(),
                        CharterResourceTypeString = c.String(),
                    })
                .PrimaryKey(t => t.CharterID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Charters");
        }
    }
}
