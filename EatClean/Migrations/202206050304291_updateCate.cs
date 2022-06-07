namespace EatClean.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class updateCate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articles", "CreatedAt", c => c.Long());
            AlterColumn("dbo.Articles", "UpdatedAt", c => c.Long());
            AlterColumn("dbo.Articles", "DeletedAt", c => c.Long());
            AlterColumn("dbo.Categories", "CreatedAt", c => c.Long());
            AlterColumn("dbo.Categories", "UpdatedAt", c => c.Long());
            AlterColumn("dbo.Categories", "DeletedAt", c => c.Long());
            AlterColumn("dbo.Tags", "CreateAt", c => c.Long());
            AlterColumn("dbo.Tags", "UpdatedAt", c => c.Long());
            AlterColumn("dbo.Tags", "DeleteAt", c => c.Long());
        }

        public override void Down()
        {
            AlterColumn("dbo.Tags", "DeleteAt", c => c.Long(nullable: false));
            AlterColumn("dbo.Tags", "UpdatedAt", c => c.Long(nullable: false));
            AlterColumn("dbo.Tags", "CreateAt", c => c.Long(nullable: false));
            AlterColumn("dbo.Categories", "DeletedAt", c => c.Long(nullable: false));
            AlterColumn("dbo.Categories", "UpdatedAt", c => c.Long(nullable: false));
            AlterColumn("dbo.Categories", "CreatedAt", c => c.Long(nullable: false));
            AlterColumn("dbo.Articles", "DeletedAt", c => c.Long(nullable: false));
            AlterColumn("dbo.Articles", "UpdatedAt", c => c.Long(nullable: false));
            AlterColumn("dbo.Articles", "CreatedAt", c => c.Long(nullable: false));
        }
    }
}
