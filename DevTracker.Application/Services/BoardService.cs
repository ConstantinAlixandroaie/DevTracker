using DevTracker.Application.Interfaces;
using DevTracker.Contracts;
using DevTracker.Contracts.Requests.Boards;
using DevTracker.Contracts.Responses.Boards;
using DevTracker.Data.Repositories.Interfaces;
using DevTracker.Domain.Boards;
using Mapster;
using MapsterMapper;

namespace DevTracker.Application.Services;

public class BoardService : IBoardService
{
    private readonly IBoardRepository _boardRepo;
    private readonly IMapper _mapper;

    public BoardService(IBoardRepository boardRepo, IMapper mapper)
    {
        _boardRepo = boardRepo;
        _mapper = mapper;
    }

    public async Task<Response> GetBoardsByUserIdAsync(long userId)
    {
        var result = await _boardRepo.GetBoardsByUserId(userId);

        if (!result.IsSuccess)
        {
            return Response.Failure(Result.Failure, result.Error);
        }

        var responseValue = result.Value!.Select(x=>x.Adapt<BoardProjection>());

        return new GetBoardsByUserIdResponse(Result.Success, responseValue);
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
