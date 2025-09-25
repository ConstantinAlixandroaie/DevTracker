using DevTracker.Data.Enums;

namespace DevTracker.Data.Records;

public record UpdateTaskItem(long TaskId,string? Title, Status? Status);
