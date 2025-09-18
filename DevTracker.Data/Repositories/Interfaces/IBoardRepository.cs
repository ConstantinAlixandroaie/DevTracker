using DevTracker.Core;
using DevTracker.Data.Models;

namespace DevTracker.Data.Repositories.Interfaces;

public interface IBoardRepository
{
    Task<Result<IEnumerable<Board>>> GetBoardsByUserId(long userId);
}
