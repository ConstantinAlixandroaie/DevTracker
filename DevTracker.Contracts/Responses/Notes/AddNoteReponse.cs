namespace DevTracker.Contracts.Responses.Notes;

public class AddNoteReponse : Response
{
    public AddNoteReponse(Result result, string? errorMessage = null) : base(result, errorMessage)
    {
    }
}
