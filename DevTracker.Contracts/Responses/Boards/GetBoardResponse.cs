using DevTracker.Domain.Boards;

namespace DevTracker.Contracts.Responses.Boards;

public class GetBoardResponse : Response
{
    public BoardProjection Board { get; set; }
    public GetBoardResponse(Result result, BoardProjection board, string? errorMessage = null) : base(result, errorMessage)
    {
        Board = board;
    }
}
