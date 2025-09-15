namespace DevTracker.Contracts.Responses.Note;

public class DeleteNoteResponse : Response
{
    public DeleteNoteResponse(Result result, string? errorMessage = null) : base(result, errorMessage)
    {
    }
}