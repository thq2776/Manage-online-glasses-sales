using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebBankinh.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel //đăng nhập
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Tên đăng nhập không được để trống!")]
        [Display(Name = "Tên tài khoản")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống!")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }


        [Display(Name = "Nhớ tài khoản?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel //đăng ký
    {
        
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email không được để trống!")]
        [EmailAddress(ErrorMessage = "Vui lòng điền đúng Email!")]
        public string Email { get; set; }

        [Display(Name = "Tên tài khoản")]
        [Required(ErrorMessage = "Tên tài khoản không được để trống!")]
        public string UserName { get; set; }

        [Display(Name = "Tên người dùng")]
        [Required(ErrorMessage = "Tên người dùng không được để trống!")]
        public string TenNguoiDung { get; set; }

        
        [Display(Name = "Số điện thoại")]
        [RegularExpression(@"^[0-9]{10,11}$", ErrorMessage = "Số điện thoại không hợp lệ")]
        [Required(ErrorMessage = "Số điện thoại không được để trống!")]
        public string SoDienThoai { get; set; }

        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Địa chỉ không được để trống!")]
        public string DiaChi { get; set; }
        
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được để trống!")]
        [StringLength(100, ErrorMessage = "Mật khẩu ít nhất phải có 6 ký tự!", MinimumLength = 6)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Nhập lại mật khẩu")]
        [Compare("Password", ErrorMessage = "Mật khẩu không trùng khớp!")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel //Đổi mật khẩu
    {
        /*[Required]*/
        /*[EmailAddress]*/
        [Display(Name = "Tên tài khoản")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu cũ!")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu cũ")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu mới!")]
        [DataType(DataType.Password)]
        [Display(Name = "Nhập mật khẩu mới")]
        /*[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]*/
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Mật khẩu không trùng khớp!")]
        [DataType(DataType.Password)]
        [Display(Name = "Nhập lại mật khẩu")]
        public string ConfirmPassword1 { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
