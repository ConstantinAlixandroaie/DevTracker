using System.ComponentModel.DataAnnotations;

namespace DevTracker.Contracts.Requests;

public class CreateTaskItemRequest
{
    [Required]
    public string TaskItemTitle { get; set; } = string.Empty;
}
