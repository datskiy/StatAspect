// ReSharper disable UnusedType.Global

using StatAspect.Application._Core.Authentication.Queries;
using StatAspect.Application.MediaTracking.Queries;
using StatAspect.Domain._Core.Authentication.Aggregates;
using StatAspect.Domain.MediaTracking.ValueObjects.Identifiers;
using StatAspect.SharedKernel.Results;

namespace StatAspect.Application._Core.Authentication.Handlers;

/// <summary>
/// Represents a generated user access token getting request handler.
/// <remarks>
/// <list type="bullet">
/// <item>Reflection only.</item>
/// </list>
/// </remarks>
/// </summary>
public sealed class GetAccessTokenHandler : IRequestHandler<GetAccessTokenQuery, OneOf<SearchKeyId, AccessDenied>>
{
    //private readonly ISearchKeyQueryRepository _searchKeyQueryRepository;

    public GetAccessTokenHandler(/*ISearchKeyQueryRepository searchKeyQueryRepository*/)
    {
        //_searchKeyQueryRepository = searchKeyQueryRepository;
    }

    /// <summary>
    /// Returns a result of processing the <see cref="GetSearchKeyQuery"/> request. // TODO: fix all
    /// <remarks>
    /// <list type="bullet">
    /// <item>Reflection only.</item>
    /// </list>
    /// </remarks>
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public async Task<OneOf<SearchKeyId, AccessDenied>> Handle(GetAccessTokenQuery request, CancellationToken cancellationToken)
    {
        Guard.Argument(() => request).NotNull();

        var userCredentials = new UserCredentials(request.Username, request.Password /*TODO: to hash*/);
        // var userIdentity = repo.SingleOrDefault(userIdentity);
        // if(userIdentity is null)
        //     return new AccessDenied();
        //
        // return accessTokenService.Issue(userIdentity, duration: new TimeSpan(0, 0, 45));
        /*
         * accessTokenGenerator.Generate();??
         *
        */
        return await Task.FromResult(new SearchKeyId(Guid.NewGuid()));
    }
}