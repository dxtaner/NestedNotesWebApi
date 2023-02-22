using Microsoft.EntityFrameworkCore;
using NotesApi.Models;

namespace NoteApi.Models
{
    public class NotesContext : DbContext
    {
        public NotesContext(DbContextOptions<NotesContext> options)
            : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }
    }
}
