namespace DevTracker.Data.Models;

public class Note
{
    public long Id { get; private set; }
    public string? Content { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; private set; } = null;
}
