using System.ComponentModel.DataAnnotations;

namespace FreeCourses.Web.Models
{
    public class SigninInput
    {
        [Display(Name = "Email adresiniz")]
        public string Email { get; set; }
        [Display(Name = "Şifreniz")]
        public string Password { get; set; }
        [Display(Name = "Beni hatırla")]
        public bool IsRemember { get; set; }
    }
}
