using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNoteCore.MVC.Models
{
    public class Note
    {
        /// <summary>
        /// Note NO is ID - PK
        /// </summary>
        [Key] // Pk
        public int NodeNo { get; set; }
        [Required(ErrorMessage ="Please Input Note Title")]
        public string NoteTitle { get; set; }

        [Required(ErrorMessage = "Please Input Contents")]
        public string  NoteContents { get; set; }
        
        /// <summary>
        /// Author No
        /// </summary>
        [Required]
        public int UserNo { get; set; }

        [ForeignKey("UserNo")]
        public virtual User user { get; set; }
    }
}
