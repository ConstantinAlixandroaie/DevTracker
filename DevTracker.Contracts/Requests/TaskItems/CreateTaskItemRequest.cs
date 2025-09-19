using System.ComponentModel.DataAnnotations;

namespace DevTracker.Contracts.Requests.TaskItems;

public class CreateTaskItemRequest
{
    [Required]
    public string TaskItemTitle { get; set; } = "";
    public long UserId { get; set; }
    public long BoardId { get; set; }
}
