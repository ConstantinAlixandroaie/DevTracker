namespace DevTracker.Core;

public sealed class Result<T>
{
    public bool IsSuccess { get; }
    public ErrorType ErrorType { get; }
    public string? Error { get; }
    public T? Value { get; }

    private Result(bool isSuccess, ErrorType errorType, string? error, T? value)
    {
        IsSuccess = isSuccess;
        Error = error;
        Value = value;
    }

    public static Result<T> Success(T value) => new(true, ErrorType.None, null, value);
    public static Result<T> Failure(ErrorType errorType, string error) => new(false, errorType, error, default);
}

public enum ErrorType
{
    None,
    NotFound,
    Validation,
    Conflict,
    Unexpected
}
