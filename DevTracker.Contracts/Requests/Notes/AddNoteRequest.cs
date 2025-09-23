using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DevTracker.Contracts.Requests.Notes;

public class AddNoteRequest
{
    [Required]
    public long TaskItemId { get; set; }
    [Required]
    public string Content { get; set; } = "";
    [JsonIgnore]
    public long UserId { get; set; }
}
