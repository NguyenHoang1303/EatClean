using EatClean.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public ActionResult Create()
        {
            return View("Product/Create");
        }
        public ActionResult StoreTag()
        {
            return View();
        }
        [HttpPost]
        public String CreateTag(string tag_name)
        {
            
            Tag tag = new Tag()
            {
                Id = 1,
      
                Name = tag_name,
                Status = 1,
                CreateAt = DateTime.Now.Ticks,
                UpdatedAt = DateTime.Now.Ticks,
                DeleteAt = 0,
            };
            try
            {
            if (!string.IsNullOrEmpty(tag.Name))
            {
                _db.Tags.Add(tag);
                _db.SaveChanges();
                return "True";
            }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "False";
        }
    }
}