using DevTracker.Contracts;
using DevTracker.Contracts.Requests.Boards;
using DevTracker.Contracts.Responses.Boards;

namespace DevTracker.Application.Interfaces;

public interface IBoardService
{
    Task<Response> GetBoardsByUserIdAsync(long userId);
    Task<Response> CreateBoardAsync(CreateBoardRequest request);
    Task<Response> DeleteBoardAsync(long boardId);
}
