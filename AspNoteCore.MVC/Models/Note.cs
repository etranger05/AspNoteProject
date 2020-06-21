using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace AspNoteCore.MVC.Models
{
    public class Note
    {
        /// <summary>
        /// Nsote NO is ID - PK
        /// </summary>
        [Key] // Pk
        public int NodeNo { get; set; }
        [Required]
        public string NoteTitle { get; set; }
        
        [Required]
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
