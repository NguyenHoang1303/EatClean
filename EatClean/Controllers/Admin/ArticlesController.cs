using EatClean.Data;
using EatClean.Entity;
using EatClean.Request;
using PagedList;
using System;
using System.Data.Entity.Migrations;
using System.Linq;
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
        public ActionResult Index(int? page)
        {
            if (page == null) page = 1;
            int pageSize = 9;
            int pageIndex = (page ?? 1);
            var articles = _db.Articles.ToList();
            PagedList.IPagedList<Article> pagedProduct = articles.ToPagedList(pageIndex, pageSize);
            ViewBag.categories = _db.Categories.ToList();
            return View("~/Views/Admin/Articles/Index.cshtml", pagedProduct);
        }

        public ActionResult Create()
        {
            ViewBag.Tags = _db.Tags.ToList();
            ViewBag.Categories = _db.Categories.ToList();
            return View("~/Views/Admin/Articles/Create.cshtml");
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
              
               
                var a = new Article()
                {
                    Title = article.title,
                    Description = article.description,
                    AuthorId = "1",
                    ArticleDetail = adt,
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

        public bool UpdateStatus(int? articleId, int? status)
        {
            var article = _db.Articles.Find(articleId);
            if (article == null)
            {
                return false;
            }
            article.Status = (int) status;
            try
            {
                _db.Articles.AddOrUpdate(article);
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