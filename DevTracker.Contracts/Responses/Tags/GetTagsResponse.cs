using DevTracker.Domain.Tags;

namespace DevTracker.Contracts.Responses.Tags;

public class GetTagsResponse : Response
{
    public IEnumerable<TagProjection> Tags { get; set; }
    public GetTagsResponse(Result result, IEnumerable<TagProjection> tags, string? errorMessage = null) : base(result, errorMessage)
    {
        Tags = tags;
    }
}
