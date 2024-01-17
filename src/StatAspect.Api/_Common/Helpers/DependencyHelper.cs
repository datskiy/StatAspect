using StatAspect.Domain._Core.Authentication.Managers;
using StatAspect.Domain._Core.UserRegistry.Managers;
using StatAspect.Domain._Core.UserRegistry.Repositories;
using StatAspect.Domain.MediaTracking.Repositories;
using StatAspect.Domain.MediaTracking.Services;
using StatAspect.Domain.MediaTracking.Services.Implementations;
using StatAspect.Infrastructure._Core.Authentication.Managers;
using StatAspect.Infrastructure._Core.UserRegistry.Managers.Implementations;
using StatAspect.Infrastructure._Core.UserRegistry.Repositories.Implementations;
using StatAspect.Infrastructure.MediaTracking.Repositories.Implementations;

namespace StatAspect.Api._Common.Helpers;

/// <summary>
/// Provides helper methods for dependency injection.
/// </summary>
public static class DependencyHelper
{
    /// <summary>
    /// Resolves service dependencies.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public static void Resolve(IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        // _Core
        services.AddTransient<IAccessPermissionManager, AccessPermissionManager>();
        services.AddTransient<IUserCredentialsManager, UserCredentialsManager>();

        services.AddTransient<IUserCredentialsQueryRepository, UserCredentialsQueryRepository>();

        // MediaTracking
        services.AddTransient<ISearchKeyService, SearchKeyService>();

        services.AddTransient<ISearchKeyCommandRepository, SearchKeyCommandRepository>();
        services.AddTransient<ISearchKeyQueryRepository, SearchKeyQueryRepository>();
    }
}