namespace DevTracker.Core;

/// <summary>
/// Represents an operation result.
/// </summary>
/// <typeparam name="T">the type of the value returned be the<see cref="Result{T}"></typeparam>
public sealed class Result<T>
{
    /// <summary>
    /// True if the operation is succesful, false otherwise.
    /// </summary>
    public bool IsSuccess { get; }
    /// <summary>
    /// Contains the type of error if the operation has failed.
    /// </summary>
    public ErrorType ErrorType { get; }
    /// <summary>
    /// Contains the error message if the operation has failed.
    /// </summary>
    public string? Error { get; }
    /// <summary>
    /// Contains a value only if <see cref="IsSuccess"/> is set to true.
    /// </summary>
    public T? Value { get; }

    private Result(bool isSuccess, ErrorType errorType, string? error, T? value)
    {
        IsSuccess = isSuccess;
        Error = error;
        ErrorType = errorType;
        Value = value;
    }
    /// <summary>
    /// Creates a new <see cref="Result{T}"/> with
    /// <see cref="IsSuccess"/> set to true and <see cref="Value"/> to 
    /// a default value.
    /// </summary>
    /// <param name="value"></param>
    /// <returns>a new instance of <see cref="Result{T}"/></returns>
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
