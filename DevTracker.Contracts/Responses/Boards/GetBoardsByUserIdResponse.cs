using DevTracker.Domain.Boards;

namespace DevTracker.Contracts.Responses.Boards;

public class GetBoardsByUserIdResponse : Response
{
    public IEnumerable<BoardProjection>? Boards { get; set; }

    public GetBoardsByUserIdResponse(Result result, IEnumerable<BoardProjection>? boards, string? errorMessage = null) : base(result, errorMessage)
    {
        Boards = boards;
    }

}
