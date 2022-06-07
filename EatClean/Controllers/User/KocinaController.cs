using EatClean.Data;
using EatClean.Entity;
using EatClean.Request;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EatClean.Entity;

namespace EatClean.Controllers.User
{

    public class KocinaController : Controller
    {
        private DataContext myIdentityDbContext; // Bên Xác thực và Phân quyền
        private UserManager<Account> userManager; //Bên database
        private RoleManager<Role> roleManager;

        public KocinaController()
        {
            myIdentityDbContext = new DataContext();  // giống Connection Helper
            UserStore<Account> userStore = new UserStore<Account>(myIdentityDbContext); // create, update, delete giống UserModel
            userManager = new UserManager<Account>(userStore); // giống Service, xử lý các vấn đề liên quan đến logic
            RoleStore<Role> roleStore = new RoleStore<Role>(myIdentityDbContext); // create, update, delete giống UserModel
            roleManager = new RoleManager<Role>(roleStore); // giống Service, xử lý các vấn đề liên quan đến logic
        }

        // GET: Kocina
        public ActionResult Index(int? page, int? categoryId, string keyword)
        {
            if (page == null) page = 1;
            int pageSize = 9;
            int pageIndex = (page ?? 1);
            var articles = myIdentityDbContext.Articles.Where(a => a.Status == 1).ToList();
            PagedList.IPagedList<Article> pagedProduct = articles.ToPagedList(pageIndex, pageSize);
            ViewBag.categories = myIdentityDbContext.Categories.ToList();
            return View(pagedProduct);
        }

        public ActionResult Recipe(int? id)
        {
            var article = myIdentityDbContext.Articles.Find(id);
            if (article == null)
            {
                ViewBag.errorArticleDt = "Bài viết bị lỗi, vui lòng quay lại sau.";
                return RedirectToAction("Index");
            }

            var a = article.ArticleDetail;
          
            ViewBag.articleDetail = a;
            ViewBag.article = article;

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Articles(int? page, string keyword, string orderBy)
        {
            List<Article> articles;
            ViewBag.Search = keyword;
            ViewBag.OrderBy = orderBy;
            if (page == null) page = 1;
            int pageSize = 8;
            int pageIndex = (page ?? 1);
            if (keyword == null)
            {
                articles = myIdentityDbContext.Articles.Where(a => a.Status == 1).ToList();
            }
            else
            {
                articles = myIdentityDbContext.Articles.Where(a => a.Status == 1).Where(p => p.Title.Contains(keyword)).Where(p => p.Description.Contains(keyword)).ToList();
            }
            if (orderBy != null)
            {
                switch (orderBy)
                {
                    case "ascending":
                        articles = articles.OrderBy(p => p.Title).ToList();
                        break;
                    case "descending":
                        articles = articles.OrderByDescending(p => p.Title).ToList();
                        break;
                    default:
                        break;
                }
            }
            PagedList.IPagedList<Article> pagedProduct = articles.ToPagedList(pageIndex, pageSize);
            return View(pagedProduct);
        }


        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult UserDetail()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = myIdentityDbContext.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
                return View(user);
            }
            else return View();
        }

        public async Task<bool> AddUserToRoleAsync(string UserId, string RoleName)
        {
            var user = myIdentityDbContext.Users.Find(UserId);
            var role = myIdentityDbContext.Roles.AsQueryable().Where(roleFind => roleFind.Name.Contains(RoleName)).FirstOrDefault();
            if (user == null || role == null)
            {
                return false;
            }
            string roleName2 = "User";
            var result = await userManager.AddToRolesAsync(UserId, roleName2); // Thêm nhiều Role cho 1 User
            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                ViewBag.Errors = result.Errors;
                System.Diagnostics.Debug.WriteLine("Lỗi tạo quyền có lỗi là ", result.Errors);
                return false;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(string Username, string Password, string Email)
        {
            long dateTime = DateTime.Now.Ticks;
            Account user = new Account()
            {
                UserName = Username,
                Password = Password,
                Email = Email,
                CreatedAt = dateTime
            };
            var result = await userManager.CreateAsync(user, Password);
            if (result.Succeeded)
            {
                var queryUser = myIdentityDbContext.Users.AsQueryable().Where(userFind => userFind.UserName.Contains(Username)).FirstOrDefault();

                if (queryUser == null)
                {
                    ViewBag.Errors = "An Error Occurred, Please Try Again!";
                    return View();
                }
                var check = userManager.AddToRole(queryUser.Id, "User");
                if (check.Succeeded)
                {
                    TempData["Success"] = "Successful Registration!";
                    return Redirect("/Kocina/Login");
                }
                else
                {
                    ViewBag.Errors = "An Error Occurred, Please Try Again!";
                    return View();
                }
            }
            else
            {
                ViewBag.Errors = "This User Name Has Already Existed!";
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(string UserName, string Password)
        {
            var user = await userManager.FindAsync(UserName, Password);
            if (user == null)
            {
                ViewBag.ErrorsLogin = "User Name Or Password Is Invalid!";
                return View();
            }
            else
            {
                SignInManager<Account, string> signInManager = new SignInManager<Account, string>(
                    userManager, Request.GetOwinContext().Authentication);
                await signInManager.SignInAsync(user, false, false);
                if (userManager.IsInRole(user.Id, "Admin"))
                {
                    return Redirect("/Articles/Create");
                }
                else return Redirect("/Kocina");
            }
        }

        public ActionResult Logout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return Redirect("/Kocina");
        }

        public ActionResult CreateArticle()
        {
            ViewBag.Tags = myIdentityDbContext.Tags.ToList();
            ViewBag.Categories = myIdentityDbContext.Categories.ToList();
            if (User.Identity.IsAuthenticated)
            {
                var user = myIdentityDbContext.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
                ViewBag.UserId = user.Id;
                return View(user);
            }
            else return View("~/View/Konaci/CreateArticle.cshtml");
        }

        [HttpPost]
        public bool CreateArticle(ArticleRequest article, string id)
        {
            if (id == null || myIdentityDbContext.Users.Find(id) == null)
            {
                return false;
            }
            if (!article.validation())
            {
                return false;
            }
            var categoty = myIdentityDbContext.Categories.Find(article.categoryId);
            var tag = myIdentityDbContext.Tags.Find(article.tagId);
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
                var saveAdt = myIdentityDbContext.ArticleDetails.Add(adt);
                myIdentityDbContext.SaveChanges();

                var a = new Article()
                {
                    Title = article.title,
                    Description = article.description,
                    AuthorId = id,
                    ArticleDetail = saveAdt,
                    Status = 0,
                    Category = categoty,
                    Tags = tag,
                    Thumbnail = article.thumbnail,
                    CreatedAt = DateTime.Now.Ticks,
                    UpdatedAt = DateTime.Now.Ticks,
                };
                myIdentityDbContext.Articles.Add(a);
                myIdentityDbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public ActionResult ArticleDetail(int? id)
        {
            if (id != null)
            {
                var articleDetail = myIdentityDbContext.ArticleDetails.Find(id);
                return View(articleDetail);
            }
            else return View("~/Shared/Error.cshtml");
        }
    }
}