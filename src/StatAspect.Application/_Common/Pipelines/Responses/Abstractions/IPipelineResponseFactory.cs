namespace StatAspect.Application._Common.Pipelines.Responses.Abstractions;

/// <summary>
/// Defines a self-producing factory for creating objects that implement <see cref="IPipelineResponseFactory{TPipelineResponse}"/>.
/// </summary>
public interface IPipelineResponseFactory<out TPipelineResponse>
    where TPipelineResponse : IPipelineResponseFactory<TPipelineResponse>
{
    /// <summary>
    /// Creates a failed pipeline response with the specified validation failures.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    static abstract TPipelineResponse CreateFailed(IImmutableList<ValidationFailure> validationFailures);
}