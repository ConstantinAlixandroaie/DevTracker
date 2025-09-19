namespace DevTracker.Contracts.Responses.Boards;

public class DeleteBoardResponse : Response
{
    public DeleteBoardResponse(Result result, string? errorMessage = null) : base(result, errorMessage)
    {
    }
}
