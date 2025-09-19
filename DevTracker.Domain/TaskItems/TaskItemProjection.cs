using DevTracker.Data.Enums;
using DevTracker.Domain.Boards;
using DevTracker.Domain.Notes;
using DevTracker.Domain.Tags;
using DevTracker.Domain.Users;

namespace DevTracker.Domain.TaskItems;

public class TaskItemProjection
{
    public long Id { get; private set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public Status Status { get; set; } = Status.ToDo;
    public List<NoteProjection> Notes { get; set; } = [];
    public List<TagProjection> Tags { get; set; } = [];
    public DateTime? CreatedAt { get; set; } = null;
    public DateTime? UpdatedAt { get; set; } = null;
    public long CreatedById { get; set; }
    public UserLite? CreatedBy { get; set; }
    public UserLite? Assignee { get; set; }
    public BoardProjection? Board { get; set; }
}
