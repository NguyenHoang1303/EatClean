using EatClean.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EatClean.Entity
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        protected DataContext _db;
        public AdminController()
        {
            this._db = new DataContext();
        }
        // GET: Admin
        public ActionResult Tag()
        {
            var tags = _db.Tags.ToList();
            return View("~/Views/Admin/Tag/Index.cshtml", tags);
        }

        public ActionResult CreateTag()
        {
            return View("~/Views/Admin/Tag/Create.cshtml");
        }
        public ActionResult CreateBook()
        {
            return View("~/Views/Admin/Book/Book.cshtml");
        }
        public ActionResult IndexBook()
        {
            return View("");
        }
        [HttpPost]
        public String StoreBook(string name, double price,string authorName,int status,string thumbnail)
        {
          Book book = new Book()
            {
                Name = name,
                Price = price,
                AuthorName= authorName,
               Status = status,
               Thumbnail = thumbnail,
          };
            try
            {
                if (!string.IsNullOrEmpty(book.Name)&&
                    !string.IsNullOrEmpty(book.AuthorName) &&
                    !string.IsNullOrEmpty(book.Thumbnail) &&
                   book.Price != null &&
                         book.Status != null
                    )
                {
                    _db.Books.Add(book);
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
        [HttpPost]
        public String CreateTag(string tag_name)
        {

            Tag tag = new Tag()
            {
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

        public ActionResult EditTag(int? id)
        {
            var tag = _db.Tags.Find(id);
            return View("~/Views/Admin/Tag/Edit.cshtml", tag);
        }

        [HttpPost]
        public bool DeleteTag(int? id)
        {
            var tag = _db.Tags.Find(id);
            if(tag == null)
            {
                return false;
            }
            else
            {
                _db.Tags.Remove(tag);
                _db.SaveChanges();
                return true;
            }
        }

        [HttpPost]
        public bool EditTag(Tag tag)
        {
            var result = _db.Tags.Find(tag.Id);
            if(result == null)
            {
                return false;
            }
            else
            {
                result.Name = tag.Name;
                result.UpdatedAt = DateTime.Now.Ticks;
                _db.Tags.AddOrUpdate(result);
                _db.SaveChanges();
                return true;
            }
        }

        public ActionResult Logout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return Redirect("/Kocina/Login");
        }
    }
}