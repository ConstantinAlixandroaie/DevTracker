using DevTracker.Core;
using DevTracker.Data.Models;
using DevTracker.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DevTracker.Data.Repositories;

internal class TagRepository : BaseRepository, ITagRepository
{
    public TagRepository(DevTrackerContext ctx, ILogger<BaseRepository> logger) : base(ctx, logger)
    {
    }

    public async Task<Result<Tag>> CreateTagAsync(string name, string colour)
    {
        var tag = new Tag
        {
            Name = name.ToLower(),
            Colour = colour.ToLower()
        };

        try
        {
            await _ctx.Tags.AddAsync(tag);
            await _ctx.SaveChangesAsync();
            return Result<Tag>.Success(tag);
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex.Message);
            return Result<Tag>.Failure(ErrorType.Conflict, ex.Message);
        }
    }

    public async Task<Result<Tag>> DeleteTagAsync(long tagId)
    {
        var tag = await _ctx.Tags.FirstOrDefaultAsync(x => x.Id == tagId);

        if (tag is null)
        {
            _logger.LogError("The Tagd does not exist");
        }

        try
        {
            _ctx.Tags.Remove(tag!);
            await _ctx.SaveChangesAsync();
            return Result<Tag>.Success(tag!);
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex.Message);
            return Result<Tag>.Failure(ErrorType.NotFound, ex.Message);
        }
    }

    public async Task<Result<Tag>> GetTagAsync(long tagId)
    {
        try
        {
            var tag = await _ctx.Tags.FirstOrDefaultAsync(x => x.Id == tagId);
            if (tag is null)
            {
                return Result<Tag>.Failure(ErrorType.NotFound, "Tag not found.");
            }

            return Result<Tag>.Success(tag!);
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex.Message);
            return Result<Tag>.Failure(ErrorType.Unexpected, ex.Message);
        }
    }

    public async Task<Result<IEnumerable<Tag>>> GetTagsAsync()
    {
        try
        {
            var tags = await _ctx.Tags.AsNoTracking().ToListAsync();
            return Result<IEnumerable<Tag>>.Success(tags);
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex.Message);
            return Result<IEnumerable<Tag>>.Failure(ErrorType.Unexpected, ex.Message);
        }
    }

    public async Task<Result<Tag>> UpdateTagAsync(long tagId, string? name, string? colour)
    {
        var tag = await _ctx.Tags.FirstOrDefaultAsync(x => x.Id == tagId);

        if (tag is null)
        {
            return Result<Tag>.Failure(ErrorType.NotFound, "Tag not found.");
        }

        if (tag.Name != name && !string.IsNullOrEmpty(name))
        {
            tag.Name = name;
        }

        if (tag.Colour != colour && !string.IsNullOrEmpty(colour))
        {
            tag.Colour = colour;
        }

        try
        {
            await _ctx.SaveChangesAsync();
            _logger.LogInformation($"Task item with {tag.Id} has been updated to {name}!");
            return Result<Tag>.Success(tag);
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex.Message);
            return Result<Tag>.Failure(ErrorType.Unexpected, ex.Message);
        }
    }
}
