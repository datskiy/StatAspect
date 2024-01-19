using StatAspect.Application._Common.Pipelines.Responses.Abstractions;

namespace StatAspect.Application._Common.Pipelines.Responses;

/// <summary>
/// Represents a pipeline response.
/// </summary>
public sealed class PipelineResponse<TResult> : IPipelineResponseFactory<PipelineResponse<TResult>>
{
    /// <summary>
    /// Gets a sequence of validation failures.
    /// </summary>
    public IImmutableList<ValidationFailure> ValidationFailures { get; }

    /// <summary>
    /// Gets a result.
    /// </summary>
    public TResult? Result { get; }

    private PipelineResponse(IImmutableList<ValidationFailure> validationFailures)
    {
        ValidationFailures = validationFailures;
        Result = default;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="PipelineResponse{TResult}"/>.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public PipelineResponse(TResult? result)
    {
        ValidationFailures = ImmutableList<ValidationFailure>.Empty;
        Result = result;
    }

    public static PipelineResponse<TResult> CreateFailed(IImmutableList<ValidationFailure> validationFailures)
    {
        ArgumentNullException.ThrowIfNull(validationFailures);

        return new PipelineResponse<TResult>(validationFailures);
    }
}