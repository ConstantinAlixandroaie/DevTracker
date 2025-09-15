namespace DevTracker.Contracts.Responses;

public class DeleteTaskItemResponse : Response
{
    public DeleteTaskItemResponse(Result result, string? errorMessage = null) : base(result, errorMessage)
    {
    }
}
