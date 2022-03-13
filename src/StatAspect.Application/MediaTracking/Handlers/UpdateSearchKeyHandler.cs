using StatAspect.Application.MediaTracking.Commands;

namespace StatAspect.Application.MediaTracking.Handlers;

/// <summary>
/// Represents a search key update request handler.
/// </summary>
public sealed class UpdateSearchKeyHandler : IRequestHandler<UpdateSearchKeyCommand>
{
    /// <summary>
    /// Returns a result of processing the <see cref="UpdateSearchKeyCommand"/> request.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public Task<Unit> Handle(UpdateSearchKeyCommand request, CancellationToken cancellationToken)
    {
        Guard.Argument(() => request).NotNull();

        return Task.FromResult(Unit.Value);
    }
}