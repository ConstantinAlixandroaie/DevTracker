using DevTracker.Contracts;
using DevTracker.Contracts.Requests.Tags;

namespace DevTracker.Application.Interfaces;

public interface ITagService
{
    Task<Response> GetTagAsync(long id);
    Task<Response> GetTagsAsync();
    Task<Response> CreateTagAsync(CreateTagRequest request);
    Task<Response> UpdateTagAsync(UpdateTagRequest request);
    Task<Response> DeleteTagAsync(long id);
}
