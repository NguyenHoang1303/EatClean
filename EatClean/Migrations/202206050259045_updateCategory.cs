namespace EatClean.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCategory : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Categories", "Thumbnail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Thumbnail", c => c.String());
        }
    }
}
