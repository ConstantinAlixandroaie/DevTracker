namespace DevTracker.Contracts.Responses.TaskItems;

public class CreateTaskItemResponse : Response
{
    public CreateTaskItemResponse(Result result, string? errorMessage = null) : base(result, errorMessage)
    {
    }
}
