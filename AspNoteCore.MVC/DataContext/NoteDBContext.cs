using AspNoteCore.MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNoteCore.MVC.DataContext
{
    public class NoteDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //optionsBuilder.UseSqlServer(@"Server=myServerAddress;Database=myDataBase;User Id=sa;Password=!Wnsks1025;");
            optionsBuilder.UseSqlServer(@"Data Source = localhost; Database=AspNoteDb; Integrated Security = True");
            
        }
    }
}
