using StatAspect.Domain.MediaTracking.Repositories;
using StatAspect.Domain.MediaTracking.Services;
using StatAspect.Domain.MediaTracking.Services.Implementations;
using StatAspect.Infrastructure.MediaTracking.Repositories.Implementations;

namespace StatAspect.Api._Common.Helpers;

/// <summary>
/// Provides static utility methods for working with dependency injection.
/// </summary>
public static class DependencyHelper
{
    /// <summary>
    /// Resolves custom transient services.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public static void ResolveTransient(IServiceCollection services)
    {
        Guard.Argument(() => services).NotNull();

        services.AddTransient<ISearchKeyService, SearchKeyService>();
        services.AddTransient<ISearchKeyQueryRepository, SearchKeyQueryRepository>();
        services.AddTransient<ISearchKeyCommandRepository, SearchKeyCommandRepository>();
    }

    /// <summary>
    /// Resolves custom scoped services.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public static void ResolveScoped(IServiceCollection services)
    {
        Guard.Argument(() => services).NotNull();

        // no specified services yet...
    }

    /// <summary>
    /// Resolves custom singleton services.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public static void ResolveSingleton(IServiceCollection services)
    {
        Guard.Argument(() => services).NotNull();

        // no specified services yet...
    }
}