using DevTracker.Data.Enums;

namespace DevTracker.Contracts.Requests.TaskItems;

public class UpdateTaskItemRequest
{
    public long TaskId { get; set; }
    public Status? Status { get; set; }
    public string? Title { get; set; }
}
