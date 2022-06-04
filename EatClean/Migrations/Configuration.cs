using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Bogus;
using EatClean.Data;
using EatClean.Entity;
using Newtonsoft.Json;

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
           
            // var articles = new List<Article>();
            // for (int i = 0; i < 10; i++)
            // {
            //     var a = new Article()
            //     {
            //         Id = i + 1,
            //         AuthorId = 1,
            //         CategoryId = 1,
            //         Title = Faker.Lorem.Sentence(),
            //         Description = Faker.Lorem.Sentence(),
            //         Thumbnail = Faker.Lorem.Paragraph(),
            //         Status = 1,
            //         CreatedAt = DateTime.Now.Ticks,
            //         UpdatedAt = DateTime.Now.Ticks,
            //         DeletedAt = DateTime.Now.Ticks 
            //     };
            //     articles.Add(a);
            // }
            //
            // var articleDetails = new List<ArticleDetail>();
            // for (int i = 0; i < 10; i++)
            // {
            //     
            //     var a = new ArticleDetail
            //     {
            //         Id = 1,
            //         Content = seedJson(),
            //         Status = 1,
            //         CreatedAt = DateTime.Now.Ticks,
            //         UpdatedAt = DateTime.Now.Ticks,
            //         DeletedAt = DateTime.Now.Ticks
            //     };
            //     articleDetails.Add(a);
            // }
            //
            // var dataContext = new DataContext();
            // articles.ForEach(a=> dataContext.Articles.AddOrUpdate(a));
            // dataContext.SaveChanges();
            // articleDetails.ForEach(a => dataContext.ArticleDetails.AddOrUpdate(a));
            // dataContext.SaveChanges();
        }

        private string seedJson()
        {
            var content = new Dictionary<string, List<string>>();
            var steps = new List<string>();
            steps.Add(Faker.Lorem.Paragraph());
            steps.Add(Faker.Lorem.Paragraph());
            steps.Add(Faker.Lorem.Paragraph());
            content.Add("steps", steps);
            var ingredients = new List<string>();
            ingredients.Add(Faker.Lorem.Paragraph());
            ingredients.Add(Faker.Lorem.Paragraph());
            ingredients.Add(Faker.Lorem.Paragraph());
            content.Add("ingredients", ingredients);
            var jsonString = JsonConvert.SerializeObject(content);
            return jsonString;
        }
    }
}