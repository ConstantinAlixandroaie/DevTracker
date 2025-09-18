namespace DevTracker.Data.Models;

public class TagTaskItemMapping
{
    public long Id { get; set; }
    public long TaskItemId { get; set; }
    public TaskItem? TaskItem { get; set; }
    public long TagId { get; set; }
    public Tag? Tag { get; set; }
}
