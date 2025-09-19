using DevTracker.Application.Interfaces;
using DevTracker.Contracts;
using DevTracker.Contracts.Requests.Boards;
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

    public async Task<CreateBoardResponse> CreateBoardAsync(CreateBoardRequest request)
    {
        var result = await _boardRepo.CreateBoardAsync(request.BoardTitle, request.UserId);

        if(!result.IsSuccess)
        {
            return new CreateBoardResponse(Result.Conflict, result.Error);
        }

        return new CreateBoardResponse(Result.Success);
    }

    public async Task<DeleteBoardResponse> DeleteBoardAsync(long boardId)
    {
        var result = await _boardRepo.DeleteBoardByIdAsync(boardId);

        if (!result.IsSuccess)
        {
            return new DeleteBoardResponse(Result.Conflict, result.Error);
        }

        return new DeleteBoardResponse(Result.Success);
    }
}
