namespace StatAspect.Application.General.Validation;

/// <summary>
/// Represents validation pipeline behavior that allows requests to be validated before passing them through the handlers.
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
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="ValidationException"/>
    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        Guard.Argument(() => request).NotNull();
        Guard.Argument(() => next).NotNull();

        var context = new ValidationContext<TRequest>(request);

        var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
        var validationFailures = validationResults
            .SelectMany(res => res.Errors)
            .Where(flr => flr is not null)
            .ToList();

        if (validationFailures.Any())
            throw new ValidationException(validationFailures);

        return await next();
    }
}