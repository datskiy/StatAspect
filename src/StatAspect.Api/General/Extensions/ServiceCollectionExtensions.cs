using StatAspect.Api.General.Helpers;
using StatAspect.Application.General.Validation;

namespace StatAspect.Api.General.Extensions;

/// <summary>
/// Provides a set of extension methods for objects that implement <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds FluentValidation services and custom pipeline behavior to the service collection.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public static void AddValidation(this IServiceCollection services, Type type)
    {
        Guard.Argument(() => services).NotNull();
        Guard.Argument(() => type).NotNull();

        services.AddFluentValidationServices(type);
        services.AddValidationPipelineBehavior();
    }

    /// <summary>
    /// Adds custom services to the service collection.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public static void AddDependencies(this IServiceCollection services)
    {
        Guard.Argument(() => services).NotNull();

        DependencyHelper.ResolveTransient(services);
        DependencyHelper.ResolveScoped(services);
        DependencyHelper.ResolveSingleton(services);
    }

    private static void AddFluentValidationServices(this IServiceCollection services, Type type)
    {
        services.AddFluentValidation(cfg =>
        {
            cfg.RegisterValidatorsFromAssemblyContaining(type);
            cfg.ValidatorOptions.LanguageManager = new ValidationLocalizationManager
            {
                Culture = CultureHelper.GetLocalizationCulture()
            };
        });
    }

    private static void AddValidationPipelineBehavior(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
    }
}