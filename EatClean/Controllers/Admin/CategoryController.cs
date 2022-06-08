using EatClean.Data;
using EatClean.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;

namespace EatClean.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
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

            List<Category> categories = dataContext.Categories.Where(c => c.Status != -1).ToList();
            ViewBag.categories = categories;
            return View("~/Views/Admin/Category/Index.cshtml");
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            List<Category> categories = dataContext.Categories.Where(c => c.Status != -1).ToList();
            ViewBag.categories = categories;
            return View("~/Views/Admin/Category/Create.cshtml");
        }

        // POST: Category/Create
        [HttpPost]
        public bool Create(string name, string description, int categoryParent)
        {
            var category = new Category()
            {
                Name = name,
                Description = description,
                ParentId = categoryParent,
                Status = 1,
                CreatedAt = DateTime.Now.Ticks,
                UpdatedAt = DateTime.Now.Ticks
            };
            if (!category.validation())
            {
                return false;
            }
            try
            {
                // TODO: Add insert logic here
                dataContext.Categories.Add(category);
                dataContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            List<Category> categories = dataContext.Categories.Where(c => c.Status != -1).ToList();
            ViewBag.categories = categories;
            var result = dataContext.Categories.Find(id);
            if (result == null)
            {
                return RedirectToAction("~/Views/Admin/Category/Index.cshtml");
            }
            ViewBag.categoryEdit = result;
            return View("~/Views/Admin/Category/Create.cshtml");
        }

        // POST: Category/Edit/5
        [HttpPost]
        public bool Edit(Category categoryEdit)
        {
            var result = dataContext.Categories.Find(categoryEdit.Id);
            if (result == null)
            {
                return false;
            }
            try
            {
                // TODO: Add update logic here
                result.Name = categoryEdit.Name;
                result.ParentId = categoryEdit.ParentId;
                result.Description = categoryEdit.Description;
                result.UpdatedAt = DateTime.Now.Ticks;
                dataContext.Categories.AddOrUpdate(result);
                dataContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // POST: Category/Delete/5
        [HttpPost]
        public bool Delete(int? id)
        {
            var result = dataContext.Categories.Find(id);
            if (result == null)
            {
                return false;
            }
            try
            {
                result.Status = -1;
                dataContext.Categories.AddOrUpdate(result);
                dataContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
