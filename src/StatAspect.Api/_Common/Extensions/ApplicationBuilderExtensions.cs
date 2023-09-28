using StatAspect.Api._Common.Models.Responses;

namespace StatAspect.Api._Common.Extensions;

/// <summary>
/// Provides a set of extension methods for types that implement <see cref="IApplicationBuilder"/>.
/// </summary>
public static class ApplicationBuilderExtensions
{
    /// <summary>
    /// Adds a middleware to the pipeline that intercepts <see cref="ValidationException"/> occurrences.
    /// Transforms the caught exceptions into <see cref="ValidationFailureResponseBody"/> errors.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public static void UseValidationExceptionHandler(this IApplicationBuilder applicationBuilder)
    {
        ArgumentNullException.ThrowIfNull(applicationBuilder);

        applicationBuilder.UseExceptionHandler(appBuilder =>
        {
            appBuilder.Run(async context =>
            {
                var caughtException = context.Features.Get<IExceptionHandlerFeature>()!.Error;
                if (caughtException is not ValidationException ex)
                    throw caughtException;

                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = MediaTypeNames.Application.Json;
                await context.Response.WriteAsync(GetValidationFailureResponseJson(ex), Encoding.UTF8);
            });
        });
    }

    private static string GetValidationFailureResponseJson(ValidationException ex)
    {
        return JsonConvert.SerializeObject(new ValidationFailureResponseBody(ex.ToImmutableErrorDictionary()));
    }
}