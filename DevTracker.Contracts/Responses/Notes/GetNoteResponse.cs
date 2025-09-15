namespace DevTracker.Contracts.Responses.Note;

public class GetNoteResponse : Response
{
    public GetNoteResponse(Result result, string? errorMessage = null) : base(result, errorMessage)
    {
    }
}
