using System.Text.Json.Serialization;

namespace DevTracker.Contracts.Requests.Tags;

public class CreateTagRequest
{
    public string Name { get; set; } = "";
    public string Colour { get; set; } = "";
    [JsonIgnore]
    public long UserId { get; set; }
}
