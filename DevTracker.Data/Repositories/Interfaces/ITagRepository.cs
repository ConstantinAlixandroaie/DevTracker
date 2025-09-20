using DevTracker.Core;
using DevTracker.Data.Models;

namespace DevTracker.Data.Repositories.Interfaces;

public interface ITagRepository
{
    Task<Result<Tag>> GetTagAsync(long tagId);
    Task<Result<IEnumerable<Tag>>> GetTagsAsync();
    Task<Result<Tag>> CreateTagAsync(string name, string colour);
    Task<Result<Tag>> UpdateTagAsync(long tagId, string? name, string? colour);
    Task<Result<Tag>> DeleteTagAsync(long tagId);

}
