using DevTracker.Contracts.Requests.Boards;
using DevTracker.Contracts.Responses.Boards;

namespace DevTracker.Application.Interfaces;

public interface IBoardService
{
    Task<GetBoardsByUserIdResponse> GetBoardsByUserIdAsync(long userId);
    Task<CreateBoardResponse> CreateBoardAsync(CreateBoardRequest request);
    Task<DeleteBoardResponse> DeleteBoardAsync(long boardId);
}
