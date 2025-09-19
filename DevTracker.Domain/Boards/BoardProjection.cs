using DevTracker.Domain.TaskItems;
using DevTracker.Domain.Users;

namespace DevTracker.Domain.Boards;

public class BoardProjection : BoardLite
{
    public List<TaskItemProjection>? TaskItems { get; set; }
    public UserLite? CreatedBy { get; set; }
    public UserLite? Owner { get; set; }
    public IEnumerable<UserLite>? Users { get; set; }
}
