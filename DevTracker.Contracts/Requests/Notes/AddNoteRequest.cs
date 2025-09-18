using System.ComponentModel.DataAnnotations;

namespace DevTracker.Contracts.Requests.Notes;

public class AddNoteRequest
{
    [Required]
    public long TaskId { get; set; }
    [Required]
    public string Content { get; set; }
}
