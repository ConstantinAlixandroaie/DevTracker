using DevTracker.Application.Interfaces;
using DevTracker.Contracts;
using DevTracker.Contracts.Responses.Boards;
using DevTracker.Data.Repositories.Interfaces;

namespace DevTracker.Application.Services;

public class BoardService : IBoardService
{
    private readonly IBoardRepository _boardRepo;

    public BoardService(IBoardRepository boardRepo)
    {
        _boardRepo = boardRepo;
    }

    public async Task<GetBoardsByUserIdResponse> GetBoardsByUserIdAsync(long userId)
    {
        var result = await _boardRepo.GetBoardsByUserId(userId);
        if (!result.IsSuccess)
        {
            return GetBoardsByUserIdResponse.Failure(Result.Failure, result.Error);
        }
        return GetBoardsByUserIdResponse.Success(Result.Success, result.Value);
    }
}
