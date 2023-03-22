using System.ComponentModel.DataAnnotations;

namespace API.ViewModels
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Login cannot be empty")]
        public string Login { get; set; }


        [Required(ErrorMessage = "Password cannot be empty")]
        public string Password { get; set; }
    }
}
