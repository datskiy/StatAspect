namespace StatAspect.Application._Common.Settings;

/// <summary>
/// Represents a validation pipeline behavior that intercepts invalid requests.
/// <remarks>Reflection usage only.</remarks>
/// </summary>
public sealed class InterceptingValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : class, IRequest<TResponse>
{
    private readonly IImmutableList<IValidator<TRequest>> _validators;

    public InterceptingValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators.ToImmutableList();
    }

    /// <summary>
    /// Validates the specified request and passes it to the next delegate.
    /// Throws a <see cref="ValidationException"/> if the request is invalid.
    /// <remarks>Reflection usage only.</remarks>
    /// </summary>
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var validationContext = new ValidationContext<TRequest>(request);
        var validationResults = await Task.WhenAll(_validators.Select(validator => validator.ValidateAsync(validationContext, cancellationToken)));
        var validationFailures = validationResults
            .SelectMany(result => result.Errors)
            .Where(failure => failure is not null)
            .ToList();

        return validationFailures.Any()
            ? throw new ValidationException(validationFailures)
            : await next();
    }
}