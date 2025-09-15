namespace DevTracker.Contracts.Responses;

public class UpdateTaskItemResponse : Response
{
    public UpdateTaskItemResponse(Result result, string? errorMessage = null) : base(result, errorMessage)
    {
    }
}
