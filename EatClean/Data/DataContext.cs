using EatClean.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

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
    }
}