using System.ComponentModel.DataAnnotations;

namespace AspNoteCore.MVC.Models
{
    public class User
    {
        /// <summary>
        /// UserNo - PK
        /// </summary>
        [Key]
        public int UserNo { get; set; }
        
        [Required(ErrorMessage ="Please input User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please input User ID")]
        public string UserId { get; set; }
        
        [Required(ErrorMessage = "Please input Password")]
        public string UserPassword { get; set; }
    }
}
