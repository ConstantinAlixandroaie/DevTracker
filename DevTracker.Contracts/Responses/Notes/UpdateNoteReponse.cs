namespace DevTracker.Contracts.Responses.Note;

public class UpdateNoteReponse : Response
{
    public UpdateNoteReponse(Result result, string? errorMessage = null) : base(result, errorMessage)
    {
    }
}
