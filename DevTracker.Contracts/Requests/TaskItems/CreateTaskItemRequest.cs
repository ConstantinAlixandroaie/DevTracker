using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DevTracker.Contracts.Requests.TaskItems;

public class CreateTaskItemRequest
{
    [Required]
    public string TaskItemTitle { get; set; } = "";
    [JsonIgnore]
    public long UserId { get; set; }
    [Required]
    public long BoardId { get; set; }
}
