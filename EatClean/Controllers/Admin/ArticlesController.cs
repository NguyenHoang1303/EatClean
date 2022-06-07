using EatClean.Data;
using EatClean.Entity;
using EatClean.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EatClean.Controllers.Admin
{
    public class ArticlesController : Controller
    {
        protected DataContext _db;
        public ArticlesController()
        {
            _db = new DataContext();
        }
        // GET: Articles
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.Tags = _db.Tags.ToList();
            ViewBag.Categories = _db.Categories.ToList();
            return View();
        }

        [HttpPost]
        public bool Create(ArticleRequest article)
        {
            if (!article.validation())
            {
                return false;
            }
            var categoty = _db.Categories.Find(article.categoryId);
            var tag = _db.Tags.Find(article.tagId);
            if (tag == null)
            {
                return false;
            }

            if (categoty == null)
            {
                return false;
            }
            var adt = new ArticleDetail()
            {
                Content = article.contents
            };

            try
            {
                var saveAdt = _db.ArticleDetails.Add(adt);
                _db.SaveChanges();

                var a = new Article()
                {
                    Title = article.title,
                    Description = article.description,
                    AuthorId = 1,
                    ArticleDetail = saveAdt,
                    Status = 1,
                    Category = categoty,
                    Tags = tag,
                    Thumbnail = article.thumbnail,
                    CreatedAt = DateTime.Now.Ticks,
                    UpdatedAt = DateTime.Now.Ticks,
                };
                _db.Articles.Add(a);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}