using StatAspect.Api._Common.Helpers;
using StatAspect.Application._Common.Settings;

namespace StatAspect.Api._Common.Extensions;

/// <summary>
/// Provides a set of extension methods for objects that implement <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds <see cref="FluentValidation"/> services and a custom pipeline behavior to the service collection.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public static void AddValidation(this IServiceCollection services, Type type)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(type);

        services.AddFluentValidationServices(type);
        services.AddValidationPipelineBehavior();
    }

    /// <summary>
    /// Adds custom services to the service collection.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public static void AddDependencies(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        DependencyHelper.ResolveTransient(services);
        DependencyHelper.ResolveScoped(services);
        DependencyHelper.ResolveSingleton(services);
    }

    private static void AddFluentValidationServices(this IServiceCollection services, Type type)
    {
        services.AddFluentValidation(cfg =>
        {
            cfg.RegisterValidatorsFromAssemblyContaining(type);
        });
    }

    private static void AddValidationPipelineBehavior(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
    }
}