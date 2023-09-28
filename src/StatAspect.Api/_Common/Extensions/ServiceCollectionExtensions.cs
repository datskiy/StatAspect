using StatAspect.Api._Common.Helpers;
using StatAspect.Application._Common.Settings;

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
        services.AddFluentValidation(cfg =>
        {
            cfg.RegisterValidatorsFromAssemblyContaining(assemblyMarkerType);
        });
    }

    private static void AddValidationPipelineBehavior(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
    }
}