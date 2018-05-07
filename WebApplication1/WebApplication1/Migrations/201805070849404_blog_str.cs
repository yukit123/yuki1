namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class blog_str : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "strBlogId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "strBlogId");
        }
    }
}
