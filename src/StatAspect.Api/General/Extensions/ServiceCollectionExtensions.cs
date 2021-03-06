using StatAspect.Api.General.Helpers;
using StatAspect.Application.General.Validation;

namespace StatAspect.Api.General.Extensions;

/// <summary>
/// Provides a set of extension methods for objects that implement <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds Fluent Validation services and custom pipeline behavior to the service collection.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public static void AddValidation(this IServiceCollection services, Assembly assembly)
    {
        Guard.Argument(() => services).NotNull();
        Guard.Argument(() => assembly).NotNull();

        services.AddFluentValidationServices(assembly);
        services.AddValidationPipelineBehavior();
    }

    /// <summary>
    /// XXX
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public static void AddDependencies(this IServiceCollection services)
    {
        Guard.Argument(() => services).NotNull();

        DependencyHelper.ResolveTransient(services);
        //todo: DependencyHelper.ResolveScoped(services);
        //todo: DependencyHelper.ResolveSingleton(services);
    }

    private static void AddFluentValidationServices(this IServiceCollection services, Assembly assembly)
    {
        Guard.Argument(() => services).NotNull();
        Guard.Argument(() => assembly).NotNull();

        services.AddFluentValidation(cfg =>
        {
            cfg.RegisterValidatorsFromAssembly(assembly);
            cfg.ValidatorOptions.LanguageManager = new ValidationLocalizationManager
            {
                Culture = CultureHelper.GetGlobalCulture(),
            };
        });
    }

    private static void AddValidationPipelineBehavior(this IServiceCollection services)
    {
        Guard.Argument(() => services).NotNull();

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
    }
}