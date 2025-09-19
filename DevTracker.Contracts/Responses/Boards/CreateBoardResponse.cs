namespace DevTracker.Contracts.Responses.Boards;

public class CreateBoardResponse : Response
{
    public CreateBoardResponse(Result result, string? errorMessage = null) : base(result, errorMessage)
    {
    }
}
