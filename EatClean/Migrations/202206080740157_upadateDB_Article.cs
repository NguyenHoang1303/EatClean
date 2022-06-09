namespace EatClean.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upadateDB_Article : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "Account_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Articles", "Account_Id");
            AddForeignKey("dbo.Articles", "Account_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "Account_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Articles", new[] { "Account_Id" });
            DropColumn("dbo.Articles", "Account_Id");
        }
    }
}
