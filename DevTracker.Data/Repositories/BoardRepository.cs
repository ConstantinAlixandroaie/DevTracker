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
            var boards = await _ctx.Boards.AsNoTracking().Where(board => board.OwnerId == userId).ToListAsync();
            return Result<IEnumerable<Board>>.Success(boards);
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex.Message);
            return Result<IEnumerable<Board>>.Failure(ErrorType.Unexpected, ex.Message);
        }

    }
}
