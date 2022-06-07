namespace EatClean.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class update_table_new_2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "Tags", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.Articles", "Tags");
        }
    }
}
