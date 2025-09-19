using DevTracker.Contracts;
using DevTracker.Contracts.Requests.Boards;

namespace DevTracker.Application.Interfaces;

public interface IBoardService
{
    Task<Response> GetBoardsByUserIdAsync(long userId);
    Task<Response> CreateBoardAsync(CreateBoardRequest request);
    Task<Response> DeleteBoardAsync(long boardId);
    Task<Response> GetBoardAsync(string id);
}
