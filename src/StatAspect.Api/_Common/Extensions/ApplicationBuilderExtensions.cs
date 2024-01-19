namespace StatAspect.Api._Common.Extensions;

/// <summary>
/// Provides a set of extension methods for types that implement <see cref="IApplicationBuilder"/>.
/// </summary>
public static class ApplicationBuilderExtensions
{
    /// <summary>
    /// Adds the Swagger middleware to the pipeline and configures setup options.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public static void UseSwaggerWithConfiguration(this IApplicationBuilder applicationBuilder)
    {
        ArgumentNullException.ThrowIfNull(applicationBuilder);

        applicationBuilder.UseSwagger();
        applicationBuilder.UseSwaggerUI(options => options.DefaultModelsExpandDepth(-1));
     }
}