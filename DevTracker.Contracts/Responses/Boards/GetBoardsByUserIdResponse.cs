using DevTracker.Domain.Boards;

namespace DevTracker.Contracts.Responses.Boards;

public class GetBoardsByUserIdResponse : Response
{
    public IEnumerable<BoardLite>? Boards { get; set; }

    public GetBoardsByUserIdResponse(Result result, IEnumerable<BoardLite>? boards, string? errorMessage = null) : base(result, errorMessage)
    {
        Boards = boards;
    }

}
