using StatAspect.Application._Common.Pipelines.Responses.Abstractions;
using StatAspect.SharedKernel.Linq.Extensions;

namespace StatAspect.Application._Common.Pipelines;

/// <summary>
/// Represents a validation pipeline behavior that intercepts invalid requests.
/// <remarks>Reflection usage only.</remarks>
/// </summary>
public sealed class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class, IRequest<TResponse>
    where TResponse : IPipelineResponseFactory<TResponse>
{
    private readonly IImmutableList<IValidator<TRequest>> _validators;

    public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators.ToImmutableList();
    }

    /// <summary>
    /// Validates the specified request and passes it to the next handler delegate.
    /// <remarks>Reflection usage only.</remarks>
    /// </summary>
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var validationContext = new ValidationContext<TRequest>(request);
        var validationFailures = await InvokeValidators(validationContext, cancellationToken);

        return validationFailures.None()
            ? await next()
            : TResponse.CreateFailed(validationFailures);
    }

    private async Task<ImmutableList<ValidationFailure>> InvokeValidators(
        IValidationContext validationContext,
        CancellationToken cancellationToken)
    {
        var validationResults = await Task.WhenAll(_validators
            .Select(validator => validator.ValidateAsync(validationContext, cancellationToken)));

        return validationResults
            .SelectMany(result => result.Errors)
            .Where(failure => failure is not null)
            .ToImmutableList();
    }
}