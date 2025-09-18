using DevTracker.Contracts.Responses.Boards;

namespace DevTracker.Application.Interfaces;

public interface IBoardService
{
    Task<GetBoardsByUserIdResponse> GetBoardsByUserIdAsync(long userId);
}
