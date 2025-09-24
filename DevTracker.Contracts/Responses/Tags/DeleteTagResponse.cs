namespace DevTracker.Contracts.Responses.Tags;

public class DeleteTagResponse : Response
{
    public DeleteTagResponse(Result result, string? errorMessage = null) : base(result, errorMessage)
    {
    }
}
