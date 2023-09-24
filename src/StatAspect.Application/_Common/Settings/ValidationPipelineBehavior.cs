namespace StatAspect.Application._Common.Settings;

/// <summary>
/// Represents validation pipeline behavior that allows requests to be validated before passing them to the handlers.
/// <remarks>Reflection only.</remarks>
/// </summary>
public sealed class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : class, IRequest<TResponse>
{
    private readonly IImmutableList<IValidator<TRequest>> _validators;

    public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators.ToImmutableList();
    }

    /// <summary>
    /// Performs incoming request validation and then passes it to the <see cref="RequestHandlerDelegate{TResponse}"/> delegate.
    /// <remarks>Reflection only.</remarks>
    /// </summary>
    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        var context = new ValidationContext<TRequest>(request);
        var validationResults = await Task.WhenAll(_validators.Select(vld => vld.ValidateAsync(context, cancellationToken)));
        var validationFailures = validationResults
            .SelectMany(res => res.Errors)
            .Where(flr => flr is not null)
            .ToList();

        return validationFailures.Any()
            ? throw new ValidationException(validationFailures)
            : await next();
    }
}