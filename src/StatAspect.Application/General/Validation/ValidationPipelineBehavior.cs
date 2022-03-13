namespace StatAspect.Application.General.Validation;

/// <summary>
/// XXX
/// </summary>
public sealed class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    /// <summary>
    /// XXX
    /// </summary>
    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
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