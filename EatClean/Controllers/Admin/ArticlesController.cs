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
    [Authorize(Roles = "Admin")]
    public class ArticlesController : Controller
    {
        protected DataContext _db;
        public ArticlesController()
        {
            _db = new DataContext();
        }
        // GET: Articles
        public ActionResult Index(int? page, string keyword, string orderBy, int? remove)
        {
            if (page == null) page = 1;
            int pageSize = 9;
            int pageIndex = (page ?? 1);
            var article = _db.Articles.Where(a => a.Status != -1);
            if (remove == 1)
            {
                article = article.Where(a => a.Status == -1);
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                article = article.Where(a => (a.Title.Contains(keyword)) || a.Description.Contains(keyword));
            }
            if (orderBy != null)
            {
                switch (orderBy)
                {
                    case "ascending":
                        article = article.OrderBy(p => p.Title);
                        break;
                    case "descending":
                        article = article.OrderByDescending(p => p.Title);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                article = article.OrderByDescending(a => a.CreatedAt);
            }
            ViewBag.Search = keyword;
            ViewBag.OrderBy = orderBy;
            PagedList.IPagedList<Article> pagedProduct = article.ToList().ToPagedList(pageIndex, pageSize);
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

        public bool UpdateStatus(int? id, int? status)
        {
            var article = _db.Articles.Find(id);
            if (article == null)
            {
                return false;
            }
            article.Status = (int)status;
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

        [HttpPost]
        public bool Delete(int? id)
        {
            var article = _db.Articles.Find(id);
            if (article == null)
            {
                return false;
            }
            try
            {
                article.Status = -1;
                article.UpdatedAt = DateTime.Now.Ticks;
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

