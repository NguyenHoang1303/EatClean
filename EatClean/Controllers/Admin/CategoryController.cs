using EatClean.Data;
using EatClean.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EatClean.Controllers.Admin
{
    public class CategoryController : Controller
    {
        private DataContext dataContext;
        public CategoryController()
        {
            dataContext = new DataContext();

        }
        // GET: Category
        public ActionResult Index()
        {
            var category = dataContext.Categories.ToList();

            return View(category);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            dataContext.Categories.Add(category);
            dataContext.SaveChanges();

            return View();
        }

        public ActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Update(Category category)
        {
            dataContext.Categories.AddOrUpdate(category);
            dataContext.SaveChanges();
            return View();
        }
        public ActionResult Delete(int id)
        {
            var category = dataContext.Categories.Find(id);
            if (category == null)
            {
                ViewBag.CategoryError = "Danh muc khong ton tai";
                return View();
            }

            ViewBag.Category = "Xoa san pham thanh cong";
            return View();
        }
        public ActionResult Search(int id, string name)
        {
            DbSet<Category> category = dataContext.Categories;
            if(id != 0)
            {
                category = (DbSet<Category>)category.Where(c => c.Id == id);
            }
            if (name != null) 
            { 
                category = (DbSet<Category>)dataContext.Categories.Where(c => c.Name.Contains(name));
            }          
            return View(category.ToList());
        }
    }
}