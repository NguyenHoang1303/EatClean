namespace EatClean.Migrations
{
    using EatClean.Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EatClean.Data.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(EatClean.Data.DataContext context)
        {
            Role roleAdmin = new Role()
            {
                Name = "Admin",
                CreatedAt = DateTime.Now.Ticks
            };
            Role roleUser = new Role()
            {
                Name = "User",
                CreatedAt = DateTime.Now.Ticks
            };
            context.Roles.Add(roleUser);
            context.Roles.Add(roleAdmin);
        }
    }
}
