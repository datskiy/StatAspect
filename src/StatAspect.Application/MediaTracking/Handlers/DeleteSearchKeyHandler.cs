using StatAspect.Application.MediaTracking.Commands;

namespace StatAspect.Application.MediaTracking.Handlers;

/// <summary>
/// Represents a search key deletion request handler.
/// </summary>
public sealed class DeleteSearchKeyHandler : IRequestHandler<DeleteSearchKeyCommand>
{
    /// <summary>
    /// Returns the result of processing the <see cref="DeleteSearchKeyCommand"/> request.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public Task<Unit> Handle(DeleteSearchKeyCommand request, CancellationToken cancellationToken)
    {
        Guard.Argument(() => request).NotNull();

        return Task.FromResult(Unit.Value);
    }
}