using DevTracker.Core;
using DevTracker.Data.Models;
using DevTracker.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DevTracker.Data.Repositories;

public class BoardRepository : BaseRepository, IBoardRepository
{
    public BoardRepository(DevTrackerContext ctx, ILogger<BaseRepository> logger) : base(ctx, logger)
    {
    }

    public async Task<Result<IEnumerable<Board>>> GetBoardsByUserId(long userId)
    {
        try
        {
            var boards = await _ctx.Boards
                .Include(x=>x.CreatedBy)
                .Include(x=>x.Owner)
                .Include(x=>x.TaskItems)
                .Where(board => board.OwnerId == userId)
                .AsNoTracking()
                .ToListAsync();

            return Result<IEnumerable<Board>>.Success(boards);
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex.Message);
            return Result<IEnumerable<Board>>.Failure(ErrorType.Unexpected, ex.Message);
        }
    }

    public async Task<Result<Board>> CreateBoardAsync(string boardTitle, long userId)
    {
        var board = new Board
        {
            Title = boardTitle,
            CreatedById = userId,
            OwnerId = userId,
        };

        try
        {
            _ctx.Boards.Add(board);
            await _ctx.SaveChangesAsync();
            return Result<Board>.Success(board);
        }
        catch (DbUpdateException ex)
        {
            return Result<Board>.Failure(ErrorType.Conflict, ex.Message);
            throw;
        }
    }

    public async Task<Result<Board>> DeleteBoardByIdAsync(long boardId)
    {
        var board = _ctx.Boards.FirstOrDefault(taskItem => taskItem.Id == boardId);

        if (board == null)
        {
            _logger.LogError("The task does not exist.");
            return Result<Board>.Failure(ErrorType.NotFound, "The task does not exist.");
        }

        try
        {
            _ctx.Boards.Remove(board);
            await _ctx.SaveChangesAsync();
            _logger.LogInformation($"Task item with {board.Id} has been deleted!");
            return Result<Board>.Success(board);
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex.Message);
            return Result<Board>.Failure(ErrorType.Unexpected, ex.Message);
        }
    }
}
