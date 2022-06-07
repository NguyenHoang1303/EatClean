using EatClean.Data;
using EatClean.Entity;
using System.Data.Entity.Migrations;

namespace EatClean.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<EatClean.Data.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EatClean.Data.DataContext context)
        {
            //var db = new DataContext();

            //db.Roles.Add(new Role()
            //{
            //    Name = "User"
            //});
            //db.Roles.Add(new Role()
            //{
            //    Name = "ADmin"
            //});
            //db.SaveChanges();
            //db.Users.Add(new Account()
            //{
            //    UserName = "admin",
            //    Password = "admin"
            //});
            //db.SaveChanges();
        }
    }
}