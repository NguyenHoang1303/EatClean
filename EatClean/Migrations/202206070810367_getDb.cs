namespace EatClean.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class getDb : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articles", "AuthorId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Articles", "AuthorId", c => c.String());
        }
    }
}
