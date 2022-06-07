namespace EatClean.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hello : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articles", "AuthorId", c => c.String());
            DropTable("dbo.Books");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        Thumbnail = c.String(),
                        AuthorName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Articles", "AuthorId", c => c.Int(nullable: false));
        }
    }
}
