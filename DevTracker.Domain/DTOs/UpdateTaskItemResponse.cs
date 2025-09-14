using DevTracker.Domain.Enums;

namespace DevTracker.Domain.DTOs;

public class UpdateTaskItemResponse : Response
{
    public UpdateTaskItemResponse(Result result, string? errorMessage = null) : base(result, errorMessage)
    {
    }
}
