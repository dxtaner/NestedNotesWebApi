namespace NotesApi.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int? ParentId { get; set; }
        // public Note? Parent { get; set; }
        // public ICollection<Note>? Children { get; set; }
    }
}