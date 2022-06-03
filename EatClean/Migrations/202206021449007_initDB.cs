namespace EatClean.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ArticleDetails", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Articles", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.ArticleDetails", "State");
            DropColumn("dbo.Articles", "State");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Articles", "State", c => c.Int(nullable: false));
            AddColumn("dbo.ArticleDetails", "State", c => c.Int(nullable: false));
            DropColumn("dbo.Articles", "Status");
            DropColumn("dbo.ArticleDetails", "Status");
        }
    }
}
