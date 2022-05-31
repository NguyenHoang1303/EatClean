using EatClean.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EatClean.Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base("EatPlane")
        {

        }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Article> Articles { get; set; }
    public DbSet<ArticleDetail> ArticleDetails { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Role> Roles { get; set; }
    }
}