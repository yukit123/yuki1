namespace TestApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customersjqgrid1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false),
                        ContactName = c.String(nullable: false),
                        ContactTitle = c.String(nullable: false),
                        Address = c.String(),
                        City = c.String(nullable: false),
                        Region = c.String(),
                        PostalCode = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Fax = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customers");
        }
    }
}
