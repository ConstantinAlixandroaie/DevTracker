using DevTracker.Application.Interfaces;
using DevTracker.Contracts;
using DevTracker.Contracts.Requests.Boards;
using DevTracker.Contracts.Responses.Boards;
using DevTracker.Core;
using DevTracker.Data.Repositories.Interfaces;
using DevTracker.Domain.Boards;
using Mapster;

namespace DevTracker.Application.Services;

public class BoardService : IBoardService
{
    private readonly IBoardRepository _boardRepo;

    public BoardService(IBoardRepository boardRepo)
    {
        _boardRepo = boardRepo;
    }

    public async Task<Response> GetBoardsByUserIdAsync(long userId)
    {
        var result = await _boardRepo.GetBoardsByUserId(userId);

        if (!result.IsSuccess)
        {
            return Response.Failure(Result.Failure, result.Error);
        }

        var responseValue = result.Value!.Select(x => x.Adapt<BoardLite>());

        return new GetBoardsByUserIdResponse(Result.Success, responseValue);
    }

    public async Task<Response> CreateBoardAsync(CreateBoardRequest request)
    {
        var result = await _boardRepo.CreateBoardAsync(request.BoardTitle, request.UserId);

        if (!result.IsSuccess)
        {
            return Response.Failure(Result.Conflict, result.Error);
        }

        return new CreateBoardResponse(Result.Success);
    }

    public async Task<Response> DeleteBoardAsync(long boardId)
    {
        var result = await _boardRepo.DeleteBoardByIdAsync(boardId);

        if (!result.IsSuccess)
        {
            return Response.Failure(Result.Conflict, result.Error);
        }

        return new DeleteBoardResponse(Result.Success);
    }

    public async Task<Response> GetBoardAsync(string id)
    {
        var boardId = long.Parse(id);
        var result = await _boardRepo.GetBoardAsync(boardId);

        if (!result.IsSuccess)
        {
            return Response.Failure(Result.NotFound, result.Error);
        }

        var response = result.Value.Adapt<BoardProjection>();

        return new GetBoardResponse(Result.Success, response);
    }

    public async Task<Response> UpdateBoardAsync(UpdateBoardRequest request)
    {
        var result = await _boardRepo.UpdateBoardAsync(request.BoardId, request.Title);

        if (!result.IsSuccess)
        {
            return Response.Failure(Result.Conflict, result.Error);
        }

        var response = result.Value.Adapt<BoardProjection>();

        return new GetBoardResponse(Result.Success, response);
    }
}
