namespace EatClean.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class updateAr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "Tags_Id", c => c.Int());
            CreateIndex("dbo.Articles", "Tags_Id");
            AddForeignKey("dbo.Articles", "Tags_Id", "dbo.Tags", "Id");
            DropColumn("dbo.ArticleDetails", "Status");
            DropColumn("dbo.ArticleDetails", "CreatedAt");
            DropColumn("dbo.ArticleDetails", "UpdatedAt");
            DropColumn("dbo.ArticleDetails", "DeletedAt");
            DropColumn("dbo.Articles", "Tags");
        }

        public override void Down()
        {
            AddColumn("dbo.Articles", "Tags", c => c.String());
            AddColumn("dbo.ArticleDetails", "DeletedAt", c => c.Long(nullable: false));
            AddColumn("dbo.ArticleDetails", "UpdatedAt", c => c.Long(nullable: false));
            AddColumn("dbo.ArticleDetails", "CreatedAt", c => c.Long(nullable: false));
            AddColumn("dbo.ArticleDetails", "Status", c => c.Int(nullable: false));
            DropForeignKey("dbo.Articles", "Tags_Id", "dbo.Tags");
            DropIndex("dbo.Articles", new[] { "Tags_Id" });
            DropColumn("dbo.Articles", "Tags_Id");
        }
    }
}
