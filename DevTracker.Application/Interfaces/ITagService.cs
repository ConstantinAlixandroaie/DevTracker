using DevTracker.Contracts;

namespace DevTracker.Application.Interfaces;

public interface ITagService
{
    Task<Response> GetTag();
    Task<Response> GetTags();
    Task<Response> CreateTag();
    Task<Response> UpdateTag();
    Task<Response> DeleteTag();
}
