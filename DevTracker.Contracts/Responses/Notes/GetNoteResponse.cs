using DevTracker.Contracts.Responses.TaskItems;
using DevTracker.Data.Models;

namespace DevTracker.Contracts.Responses.Notes;

public class GetNoteResponse : Response
{
    public IEnumerable<Note>? Notes { get; set; }
    public GetNoteResponse(Result result, IEnumerable<Note>? notes = null, string? errorMessage = null) : base(result, errorMessage)
    {
        Notes = notes;
    }
    public static GetNoteResponse Success(Result result, IEnumerable<Note>? notes) => new(result, notes, null);
    public static GetNoteResponse Failure(Result result, string? error) => new(result, null, error);
}
