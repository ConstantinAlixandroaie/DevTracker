using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DevTracker.Contracts.Requests.Notes;

public class UpdateNoteRequest
{
    [Required]
    public long NoteId { get; set; }
    [Required]
    public string Content { get; set; } = "";
    [JsonIgnore]
    public long UserId { get; set; }
}
