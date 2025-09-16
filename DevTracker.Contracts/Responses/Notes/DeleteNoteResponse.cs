namespace DevTracker.Contracts.Responses.Notes;

public class DeleteNoteResponse : Response
{
    public DeleteNoteResponse(Result result, string? errorMessage = null) : base(result, errorMessage)
    {
    }
}