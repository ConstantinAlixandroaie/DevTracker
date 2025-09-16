using DevTracker.Data.Models;

namespace DevTracker.Contracts.Responses.Notes;

public class UpdateNoteReponse : Response
{
    public Note Note { get; set; }
    public UpdateNoteReponse(Result result,Note? note, string? errorMessage = null) : base(result, errorMessage)
    {
        Note = note;
    }
    public static UpdateNoteReponse Success(Result result, Note? note) => new(result, note, null);
    public static UpdateNoteReponse Failure(Result result, string? error) => new(result, null, error);

}
