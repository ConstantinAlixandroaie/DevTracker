using DevTracker.Data.Enums;

namespace DevTracker.Data.Models;

public class TaskItem
{
    public long Id { get; private set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public Status Status { get; set; } = Status.ToDo;
    public List<Note> Notes { get; set; } = [];
    public List<Tag> Tags { get; set; } = [];
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = null;
    public long CreatedById { get; set; }
    public User? CreatedBy { get; set; }
    public long AssigneeId { get; set; }
    public User? Assignee { get; set; }
    public long BoardId { get; set; }
    public Board? Board { get; set; }
}
