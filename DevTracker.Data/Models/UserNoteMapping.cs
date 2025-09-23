namespace DevTracker.Data.Models;

public class UserNoteMapping
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public User? User { get; set; }
    public long NoteId { get; set; }
    public Note? Note { get; set; }
}
