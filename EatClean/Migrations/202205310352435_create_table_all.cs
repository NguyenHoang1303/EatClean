namespace EatClean.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_all : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        RoleId = c.Int(nullable: false),
                        ProfileId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        CreatedAt = c.Long(nullable: false),
                        UpdatedAt = c.Long(nullable: false),
                        DeletedAt = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ArticleDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        Content = c.String(),
                        State = c.Int(nullable: false),
                        CreatedAt = c.Long(nullable: false),
                        UpdatedAt = c.Long(nullable: false),
                        DeletedAt = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        Thumbnail = c.String(),
                        State = c.Int(nullable: false),
                        CreatedAt = c.Long(nullable: false),
                        UpdatedAt = c.Long(nullable: false),
                        DeletedAt = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentId = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Thumbnail = c.String(),
                        Status = c.Int(nullable: false),
                        CreatedAt = c.Long(nullable: false),
                        UpdatedAt = c.Long(nullable: false),
                        DeletedAt = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        RoleId = c.Int(nullable: false),
                        ProfileId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        CreatedAt = c.Long(nullable: false),
                        UpdatedAt = c.Long(nullable: false),
                        DeletedAt = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Roles");
            DropTable("dbo.Categories");
            DropTable("dbo.Articles");
            DropTable("dbo.ArticleDetails");
            DropTable("dbo.Accounts");
        }
    }
}
