namespace DevTracker.Contracts.Responses.Notes;

public class UpdateNoteReponse : Response
{
    public UpdateNoteReponse(Result result, string? errorMessage = null) : base(result, errorMessage)
    {
    }
}
