using EatClean.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EatClean.Entity
{
    public class AdminController : Controller
    {
        protected DataContext _db;
        public AdminController()
        {
            this._db = new DataContext();
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Store()
        {
            return View("Form");
        }
        public ActionResult StoreTag()
        {
            return View();
        }
        [HttpPost]
        public Boolean CreateTag(string TagName)
        {
            Tag tag = new Tag()
            {
                Name = TagName,
            };
            if (!string.IsNullOrEmpty(tag.Name))
            {
                _db.Tags.Add(tag);
                return true;
            }
            return false;
        }
    }
}