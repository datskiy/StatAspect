using StatAspect.Api._Common.Helpers;
using StatAspect.Application._Common.Settings;
using StatAspect.Application._Core.Authentication.Options;

namespace StatAspect.Api._Common.Extensions;

/// <summary>
/// Provides a set of extension methods for types that implement <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds validation services and custom validation pipeline behavior to the service collection.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public static void AddValidation(this IServiceCollection services, Type assemblyMarkerType)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(assemblyMarkerType);

        services.AddFluentValidationServices(assemblyMarkerType);
        services.AddValidationPipelineBehavior();
    }

    /// <summary>
    /// Adds mediator services to the service collection.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public static void AddMediator(this IServiceCollection services, params Type[] assemblyMarkerTypes)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(assemblyMarkerTypes);

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblyMarkerTypes
            .Select(type => type.Assembly)
            .ToArray()));
    }

    /// <summary>
    /// Adds configuration options to the service collection.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public static void AddOptions(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configuration);

        services.AddOptions<AuthenticationPolicies>().Bind(configuration.GetSection(nameof(AuthenticationPolicies)));
    }

    /// <summary>
    /// Adds custom services to the service collection.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public static void AddDependencies(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        DependencyHelper.ResolveSingleton(services);
        DependencyHelper.ResolveScoped(services);
        DependencyHelper.ResolveTransient(services);
    }

    private static void AddFluentValidationServices(this IServiceCollection services, Type assemblyMarkerType)
    {
        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();
        services.AddValidatorsFromAssemblyContaining(assemblyMarkerType);
    }

    private static void AddValidationPipelineBehavior(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
    }
}