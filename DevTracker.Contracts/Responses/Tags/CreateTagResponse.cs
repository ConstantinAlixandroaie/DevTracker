namespace DevTracker.Contracts.Responses.Tags;

public class CreateTagResponse : Response
{
    public CreateTagResponse(Result result, string? errorMessage = null) : base(result, errorMessage)
    {
    }
}
