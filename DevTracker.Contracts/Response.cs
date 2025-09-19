using DevTracker.Contracts.Responses.Boards;

namespace DevTracker.Contracts;
/// <summary>
/// Base class for responses returned by services.
/// </summary>
public class Response
{
    /// <summary>
    /// Shows the state of the response from <see cref="Result"/>
    /// </summary>
    public Result Result { get; set; }
    /// <summary>
    /// Contains the error message returned by the action.
    /// </summary>
    public string? ErrorMessage { get; set; }

    public Response(Result result, string? errorMessage = null)
    {
        Result = result;
        ErrorMessage = errorMessage;
    }

    public static Response Failure(Result result, string? error) => new(result, error);

}

public enum Result
{
    Success,
    Failure,
    NotFound,
    Conflict
}

