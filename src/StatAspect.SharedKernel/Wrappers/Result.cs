namespace StatAspect.SharedKernel.Wrappers;

/// <summary>
/// Represents the result of an action.
/// </summary>
public class Result
{
    private string _errorMessage = string.Empty;

    /// <summary>
    /// Indicates whether the specified result is successful.
    /// </summary>
    public bool IsSuccess { get; }

    /// <summary>
    /// Indicates whether the specified result is failed.
    /// </summary>
    public bool IsFailure => !IsSuccess;

    /// <summary>
    /// Returns the specified error message.
    /// </summary>
    public string ErrorMessage
    {
        get => IsFailure
            ? _errorMessage
            : throw new InvalidOperationException("Reading an error message is incorrect for a successful result.");

        protected init => _errorMessage = value;
    }

    protected Result(bool isSuccess, string? errorMessageIfFailure)
    {
        if (isSuccess)
        {
            if (errorMessageIfFailure is not null)
                throw new InvalidOperationException("The error message is inappropriate for a successful result.");

            IsSuccess = isSuccess;
            ErrorMessage = string.Empty;
        }
        else
        {
            if (errorMessageIfFailure is null)
                throw new InvalidOperationException("The error message cannot be null.");

            IsSuccess = isSuccess;
            ErrorMessage = errorMessageIfFailure;
        }
    }

    /// <summary>
    /// Creates an instance of the success result.
    /// </summary>
    public static Result Success() => new Result(true, null);

    /// <summary>
    /// Creates an instance of the failure result.
    /// </summary>
    public static Result Failure(string errorMessage)
    {
        _ = errorMessage ?? throw new ArgumentNullException(nameof(errorMessage));

        return new Result(false, errorMessage);
    }


    /// <summary>
    /// Returns the first found failure result or returns success.
    /// </summary>
    public static Result Check(params Result[] results)
    {
        _ = results ?? throw new ArgumentNullException(nameof(results));

        foreach (var result in results)
            if (result.IsFailure)
                return result;

        return Success();
    }
}