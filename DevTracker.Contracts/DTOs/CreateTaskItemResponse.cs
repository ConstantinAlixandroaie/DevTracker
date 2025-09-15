using DevTracker.Domain.Enums;

namespace DevTracker.Contracts.DTOs;

public class CreateTaskItemResponse : Response
{
    public CreateTaskItemResponse(Result result, string? errorMessage = null) : base(result, errorMessage)
    {
    }
}
