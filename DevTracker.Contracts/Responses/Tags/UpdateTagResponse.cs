namespace DevTracker.Contracts.Responses.Tags;

public class UpdateTagResponse : Response
{
    public UpdateTagResponse(Result result, string? errorMessage = null) : base(result, errorMessage)
    {
    }
}
