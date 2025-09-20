namespace DevTracker.Contracts.Requests.Tags;

public class UpdateTagRequest
{
    public long TagId { get; set; }
    public string? Name { get; set; }
    public string? Colour { get; set; }
}
