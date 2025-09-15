using DevTracker.Domain.Enums;

namespace DevTracker.Contracts.DTOs;

public class DeleteTaskItemResponse : Response
{
    public DeleteTaskItemResponse(Result result, string? errorMessage = null) : base(result, errorMessage)
    {
    }
}
