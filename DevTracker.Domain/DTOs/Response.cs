using DevTracker.Domain.Enums;

namespace DevTracker.Domain.DTOs;

public class Response
{
    public Result Result { get; set; }
    public string? ErrorMessage { get; set; }

    public Response(Result result, string? errorMessage = null)
    {
        Result = result;
        ErrorMessage = errorMessage;
    }
}

