namespace DevTracker.Data.Models;

public class Note
{
    public long Id { get; private set; }
    public string? Content { get; set; }
    public long TaskItemId { get; set; }
    public TaskItem? TaskItem { get; set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = null;
    public long CreatedById { get; set; }
    public User? CreatedBy { get; set; }
    public long UpdatedById { get; set; }
    public User? UpdatedBy { get; set; }
}
