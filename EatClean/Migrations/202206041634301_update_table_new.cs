namespace EatClean.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class update_table_new : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "ArticleDetail_Id", c => c.Int());
            AddColumn("dbo.Articles", "Category_Id", c => c.Int());
            CreateIndex("dbo.Articles", "ArticleDetail_Id");
            CreateIndex("dbo.Articles", "Category_Id");
            AddForeignKey("dbo.Articles", "ArticleDetail_Id", "dbo.ArticleDetails", "Id");
            AddForeignKey("dbo.Articles", "Category_Id", "dbo.Categories", "Id");
            DropColumn("dbo.Articles", "CategoryId");
        }

        public override void Down()
        {
            AddColumn("dbo.Articles", "CategoryId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Articles", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Articles", "ArticleDetail_Id", "dbo.ArticleDetails");
            DropIndex("dbo.Articles", new[] { "Category_Id" });
            DropIndex("dbo.Articles", new[] { "ArticleDetail_Id" });
            DropColumn("dbo.Articles", "Category_Id");
            DropColumn("dbo.Articles", "ArticleDetail_Id");
        }
    }
}
