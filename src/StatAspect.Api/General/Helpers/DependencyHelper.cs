using StatAspect.Domain.MediaTracking.Repositories;
using StatAspect.Domain.MediaTracking.Services;
using StatAspect.Domain.MediaTracking.Services.Implementations;
using StatAspect.Infrastructure.MediaTracking.Repositories.Implementations;

namespace StatAspect.Api.General.Helpers;

/// <summary>
/// XXX
/// </summary>
public static class DependencyHelper
{
    /// <summary>
    /// XXX
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public static void ResolveTransient(IServiceCollection services)
    {
        Guard.Argument(() => services).NotNull();

        services.AddTransient<ISearchKeyService, SearchKeyService>();
        services.AddTransient<ISearchKeyQueryRepository, SearchKeyQueryRepository>();
        services.AddTransient<ISearchKeyCommandRepository, SearchKeyCommandRepository>();
    }
}