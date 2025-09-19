using DevTracker.Core;
using DevTracker.Data.Models;

namespace DevTracker.Data.Repositories.Interfaces;

public interface IBoardRepository
{
    Task<Result<IEnumerable<Board>>> GetBoardsByUserId(long userId);
    Task<Result<Board>> CreateBoardAsync(string boardTitle, long userId);
    Task<Result<Board>> DeleteBoardByIdAsync(long boardId);
    Task<Result<Board>> GetBoardAsync(long boardId);
}
