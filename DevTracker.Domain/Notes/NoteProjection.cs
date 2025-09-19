using DevTracker.Domain.TaskItems;
using DevTracker.Domain.Users;

namespace DevTracker.Domain.Notes;

public class NoteProjection
{
    public long Id { get; private set; }
    public string? Content { get; set; }
    public TaskItemProjection? TaskItem { get; set; }
    public DateTime? CreatedAt { get; private set; } = null;
    public DateTime? UpdatedAt { get; set; } = null;
    public UserLite? CreatedBy { get; set; }
}
