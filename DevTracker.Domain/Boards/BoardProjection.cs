using DevTracker.Domain.TaskItems;
using DevTracker.Domain.Users;

namespace DevTracker.Domain.Boards;

public class BoardProjection
{
    public long Id { get; set; }
    public string Title { get; set; } = "";
    public List<TaskItemProjection>? TaskItems { get; set; }
    public UserLite? CreatedBy { get; set; }
    public UserLite? Owner { get; set; }
    public IEnumerable<UserLite>? Users { get; set; }
}
