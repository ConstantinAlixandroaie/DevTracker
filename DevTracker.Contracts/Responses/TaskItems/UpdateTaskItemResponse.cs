namespace DevTracker.Contracts.Responses.TaskItems;

public class UpdateTaskItemResponse : Response
{
    public UpdateTaskItemResponse(Result result, string? errorMessage = null) : base(result, errorMessage)
    {
    }
}
