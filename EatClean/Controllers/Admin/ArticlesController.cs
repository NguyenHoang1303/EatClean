using EatClean.Data;
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
            return View("~/Views/Admin/Articles/Create.cshtml");
        }
    }
}