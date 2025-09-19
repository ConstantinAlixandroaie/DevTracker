namespace DevTracker.Data.Models;

public class Board
{
    public long Id { get; set; }
    public string Title { get; set; } = "";
    public List<TaskItem>? TaskItems { get; set; }
    public long CreatedById { get; set; }
    public User? CreatedBy { get; set; }
    public long OwnerId { get; set; }
    public User? Owner { get; set; }
    public IEnumerable<User>? Users { get; set; }
}