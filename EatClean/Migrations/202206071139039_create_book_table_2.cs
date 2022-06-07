namespace EatClean.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_book_table_2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        Status = c.Int(nullable: false),
                        Thumbnail = c.String(),
                        AuthorName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Articles", "AuthorId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Articles", "AuthorId", c => c.String());
            DropTable("dbo.Books");
        }
    }
}
