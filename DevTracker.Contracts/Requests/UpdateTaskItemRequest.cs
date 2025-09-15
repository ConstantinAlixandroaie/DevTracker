using DevTracker.Data.Enums;

namespace DevTracker.Contracts.Requests;

public class UpdateTaskItemRequest
{
    public long TaskId { get; set; }
    public Status Status { get; set; }
}
