using DevTracker.Data.Models;

namespace DevTracker.Contracts.Responses.Boards;

public class GetBoardsByUserIdResponse : Response
{
    public IEnumerable<Board>? Boards { get; set; }

    public GetBoardsByUserIdResponse(Result result, IEnumerable<Board>? boards, string? errorMessage = null) : base(result, errorMessage)
    {
        Boards = boards;
    }
    public static GetBoardsByUserIdResponse Success(Result result, IEnumerable<Board>? boards) => new(result, boards, null);
    public static GetBoardsByUserIdResponse Failure(Result result, string? error) => new(result, null, error);
}
