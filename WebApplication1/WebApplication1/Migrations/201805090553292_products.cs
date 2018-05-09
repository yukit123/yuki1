namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class products : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        product_id = c.Int(nullable: false, identity: true),
                        model_code = c.String(),
                        full_product_name = c.String(),
                    })
                .PrimaryKey(t => t.product_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
        }
    }
}
