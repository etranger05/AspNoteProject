using System.ComponentModel.DataAnnotations;

namespace AspNoteCore.MVC.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please input User ID")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Please input Password")]
        public string UserPassword { get; set; }
    }
}
