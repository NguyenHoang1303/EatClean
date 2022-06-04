using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EatClean.Controllers.Admin
{
    public class ArticlesController : Controller
    {
        // GET: Articles
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View("~/Views/Admin/Articles/Create.cshtml");
        }
    }
}