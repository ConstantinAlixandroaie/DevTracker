using DevTracker.Domain.Enums;

namespace DevTracker.Contracts.DTOs;

public class UpdateTaskItemRequest
{
    public long TaskId { get; set; }
    public Status Status { get; set; }
}
