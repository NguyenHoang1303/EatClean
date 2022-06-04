using EatClean.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace EatClean.Data
{
    public class DataContext : IdentityDbContext<Account>
    {
        public DataContext() : base("EatPlane")
        {

        }
    public DbSet<Article> Articles { get; set; }
    public DbSet<ArticleDetail> ArticleDetails { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Tag> Tags { get; set; }
    }
}