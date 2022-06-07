using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EatClean.Entity
{
    public class UserViewModel
    {
        [DisplayName("User Name")]
        [Required(ErrorMessage = "Vui lòng nhập Tên tài khoản")]
        public string UserName { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Độ dài tối thiểu là 6, lớn nhất là 20")]
        public string Password { get; set; }
        public string Email { get; set; }
    }
}