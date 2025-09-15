namespace DevTracker.Contracts.Responses.TaskItems;

public class DeleteTaskItemResponse : Response
{
    public DeleteTaskItemResponse(Result result, string? errorMessage = null) : base(result, errorMessage)
    {
    }
}
