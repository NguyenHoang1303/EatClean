using EatClean.Data;
using EatClean.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Recipe()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Articles()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
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
            var result = await userManager.AddToRolesAsync(UserId,  roleName2); // Thêm nhiều Role cho 1 User
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
    }
}