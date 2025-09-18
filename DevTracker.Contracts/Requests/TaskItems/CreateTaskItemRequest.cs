using System.ComponentModel.DataAnnotations;

namespace DevTracker.Contracts.Requests.TaskItems;

public class CreateTaskItemRequest
{
    [Required]
    public string TaskItemTitle { get; set; } = string.Empty;
}
