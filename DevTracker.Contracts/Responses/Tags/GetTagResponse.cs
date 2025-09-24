using DevTracker.Domain.Tags;

namespace DevTracker.Contracts.Responses.Tags;

public class GetTagResponse : Response
{
    public TagProjection TagProjection { get; set; }
    public GetTagResponse(Result result, TagProjection tag, string? errorMessage = null) : base(result, errorMessage)
    {
        TagProjection = tag;
    }
}
