namespace EatClean.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class create_table_new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Status = c.Int(nullable: false),
                    CreateAt = c.Long(nullable: false),
                    UpdatedAt = c.Long(nullable: false),
                    DeleteAt = c.Long(nullable: false),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.Tags");
        }
    }
}
