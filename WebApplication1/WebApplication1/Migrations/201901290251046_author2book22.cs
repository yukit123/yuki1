namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class author2book22 : DbMigration
    {
        //搞错了 本来想 注释TestApplication1.Models.book2中的[ForeignKey("Author_id")]，忘记切换了
        public override void Up()
        {

        }

        public override void Down()
        {
        }
    }
}
