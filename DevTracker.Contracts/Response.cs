namespace DevTracker.Contracts;

public class Response
{
    public Result Result { get; set; }
    public string? ErrorMessage { get; set; }

    public Response(Result result, string? errorMessage = null)
    {
        Result = result;
        ErrorMessage = errorMessage;
    }
}

public enum Result
{
    Success,
    Failure,
    NotFound,
    Conflict
}

