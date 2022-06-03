namespace EatClean.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDb : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ArticleDetails", "CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ArticleDetails", "CategoryId", c => c.Int(nullable: false));
        }
    }
}
