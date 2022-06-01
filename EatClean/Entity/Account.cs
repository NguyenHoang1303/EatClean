using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace EatClean.Entity
{
    public class Account: IdentityUser
    {
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int ProfileId { get; set; }
        public int Status { get; set; }
        public long CreatedAt { get; set; }
        public long UpdatedAt { get; set; }
        public long DeletedAt { get; set; }

        public Account(UserViewModel userViewModel)
        {
            this.UserName = userViewModel.UserName;
            this.PasswordHash = userViewModel.Password;
            this.Email = userViewModel.Email;
        }

        public Account()
        {
        }
    }
}