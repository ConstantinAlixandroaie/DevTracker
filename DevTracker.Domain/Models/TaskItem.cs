using DevTracker.Domain.Enums;

namespace DevTracker.Domain.Models;

public class TaskItem
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Title { get; private set; }
    public Status Status { get; private set; } = Status.ToDo;
    public List<Note> Notes { get; private set; } = new();
    public List<string> Tags { get; private set; } = new();
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    public TaskItem(string title, List<string>? tags = null)
    {
        Title = title ?? throw new ArgumentNullException(nameof(title));
        if (tags != null)
            Tags = tags;
    }
}
