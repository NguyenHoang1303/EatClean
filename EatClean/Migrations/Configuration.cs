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
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EatClean.Data.DataContext context)
        {
            var adminRole = new Role()
            {
                Name = "Admin",
                CreatedAt = DateTime.Now.Ticks,
                UpdatedAt = DateTime.Now.Ticks
            };
            var userRole = new Role()
            {
                Name = "User",
                CreatedAt = DateTime.Now.Ticks,
                UpdatedAt = DateTime.Now.Ticks
            };
            context.Roles.Add(adminRole);
            context.Roles.Add(userRole);
            context.SaveChanges();
        }
    }
}
