using StatAspect.Api._Common.Formatters;
using StatAspect.Api._Common.Helpers;
using StatAspect.Application._Common.Pipelines;
using StatAspect.Application._Core.Authentication.Options;
using StatAspect.SharedKernel.IO.Glossaries;

namespace StatAspect.Api._Common.Extensions;

/// <summary>
/// Provides a set of extension methods for types that implement <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds configuration options to the service collection.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public static void AddOptions(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configuration);

        services
            .AddOptions<AuthenticationPolicies>()
            .Bind(configuration.GetSection(nameof(AuthenticationPolicies)));
    }

    /// <summary>
    /// Adds API controller services to the service collection.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public static void AddApiControllers(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services
            .AddControllers()
            .AddJsonOptions(options => options.AllowInputFormatterExceptionMessages = false);
    }

    /// <summary>
    /// Adds Swagger services to the service collection.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public static void AddSwagger(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddSwaggerGen(options =>
        {
            options.AddSwaggerDocumentation();
            options.AddSwaggerXmlComments();
            options.AddSwaggerSchemaConfiguration();
        });
    }

    /// <summary>
    /// Adds validation services and a validation pipeline behavior to the service collection.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public static void AddValidation(this IServiceCollection services, Type assemblyMarkerType)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(assemblyMarkerType);

        services.AddFluentValidationIntegration();
        services.AddValidatorsFromAssemblyContaining(assemblyMarkerType);
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
    /// Adds a property-based JSON metadata formatter to the service collection.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public static void AddJsonPropertyMetadataFormatter(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddSingleton<IConfigureOptions<MvcOptions>, JsonPropertyMetadataFormatter>();
    }

    /// <summary>
    /// Adds dependencies to the service collection.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public static void AddDependencies(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        DependencyHelper.Resolve(services);
    }

    private static void AddSwaggerDocumentation(this SwaggerGenOptions options)
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "StatAspect API",
            Description = "StatAspect REST API documentation"
        });
    }

    private static void AddSwaggerXmlComments(this SwaggerGenOptions options)
    {
        var xmlDocumentationFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.{FileExtensions.Xml}";
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlDocumentationFileName));
    }

    private static void AddSwaggerSchemaConfiguration(this SwaggerGenOptions options)
    {
        options.DocInclusionPredicate((_, _) => true);
        options.TagActionsBy(api => new[] { api.GroupName });
    }

    private static void AddFluentValidationIntegration(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();
    }

    private static void AddValidationPipelineBehavior(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
    }
}