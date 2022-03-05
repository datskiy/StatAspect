using StatAspect.Application.MediaTracking.Commands;
using StatAspect.Domain.MediaTracking.Identifiers;

namespace StatAspect.Application.MediaTracking.Handlers;

/// <summary>
/// Represents a new search key addition request handler.
/// </summary>
public sealed class AddSearchKeyHandler : IRequestHandler<AddSearchKeyCommand, SearchKeyId>
{
    /// <summary>
    /// Returns the result of processing the <see cref="AddSearchKeyCommand"/> request.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public Task<SearchKeyId> Handle(AddSearchKeyCommand request, CancellationToken cancellationToken)
    {
        Guard.Argument(() => request).NotNull();

        return Task.FromResult(new SearchKeyId(123));
    }
}