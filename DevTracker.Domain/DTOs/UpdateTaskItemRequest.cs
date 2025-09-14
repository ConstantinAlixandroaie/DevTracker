using DevTracker.Domain.Enums;

namespace DevTracker.Domain.DTOs;

public class UpdateTaskItemRequest
{
    public long TaskId { get; set; }
    public Status Status { get; set; }
}
