using System.ComponentModel.DataAnnotations;

namespace DevTracker.Contracts.Requests.Notes;

public class UpdateNoteRequest
{
    [Required]
    public long NoteId { get; set; }
    [Required]
    public string Content { get; set; }
}
