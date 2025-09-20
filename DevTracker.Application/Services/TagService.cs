using DevTracker.Application.Interfaces;
using DevTracker.Contracts;
using DevTracker.Contracts.Requests.Tags;
using DevTracker.Contracts.Responses.Tags;
using DevTracker.Data.Repositories.Interfaces;
using DevTracker.Domain.Tags;
using Mapster;

namespace DevTracker.Application.Services;

public class TagService : ITagService
{
    private readonly ITagRepository _tagRepo;
    public TagService(ITagRepository tagRepo)
    {
        _tagRepo = tagRepo;
    }

    public async Task<Response> CreateTagAsync(CreateTagRequest request)
    {
        var result = await _tagRepo.CreateTagAsync(request.Name, request.Colour);

        if (!result.IsSuccess)
        {
            return Response.Failure(Result.Conflict, result.Error);
        }

        return new CreateTagResponse(Result.Success);
    }

    public async Task<Response> DeleteTagAsync(long id)
    {
        var result = await _tagRepo.DeleteTagAsync(id);

        throw new NotImplementedException();
    }

    public async Task<Response> GetTag(long id)
    {
        var result = await _tagRepo.GetTagAsync(id);
        if (!result.IsSuccess)
        {
            return Response.Failure(Result.NotFound, result.Error);
        }
        var resultValue = result.Value.Adapt<TagProjection>();

        return new GetTagResponse(Result.Success, resultValue);
    }

    public async Task<Response> GetTags()
    {
        var result = await _tagRepo.GetTagsAsync();

        if (!result.IsSuccess)
        {
            return Response.Failure(Result.NotFound, result.Error);
        }
        var resultValue = result.Value!.Select(x => x.Adapt<TagProjection>());

        return new GetTagsResponse(Result.Success, resultValue);
    }

    public async Task<Response> UpdateTag(UpdateTagRequest request)
    {
        var result = await _tagRepo.UpdateTagAsync(request.TagId, request.Name, request.Colour);
        if (!result.IsSuccess)
        {
            return Response.Failure(Result.Failure, result.Error);
        }
        return new UpdateTagResponse(Result.Success);
    }
}
