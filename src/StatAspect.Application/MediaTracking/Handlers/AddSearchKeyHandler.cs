using StatAspect.Application.MediaTracking.Commands;

namespace StatAspect.Application.Handlers.MediaTracking;

/// <summary>
/// Represents a new search key addition request handler.
/// </summary>
public sealed class AddSearchKeyHandler : IRequestHandler<AddSearchKeyCommand, int> // todo: int to valueObject
{
    /// <summary>
    /// Returns the result of processing the <see cref="AddSearchKeyCommand"/> request.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public Task<int> Handle(AddSearchKeyCommand request, CancellationToken cancellationToken)
    {
        Guard.Argument(() => request).NotNull();

        return Task.FromResult(123);
    }
}