namespace DevTracker.Contracts.Responses.Note;

public class AddNoteReponse : Response
{
    public AddNoteReponse(Result result, string? errorMessage = null) : base(result, errorMessage)
    {
    }
}
