using DevTracker.Contracts;
using DevTracker.Contracts.Requests.Tags;

namespace DevTracker.Application.Interfaces;

public interface ITagService
{
    Task<Response> GetTag(long id);
    Task<Response> GetTags();
    Task<Response> CreateTagAsync(CreateTagRequest request);
    Task<Response> UpdateTag(UpdateTagRequest request);
    Task<Response> DeleteTagAsync(long id);
}
