using StatAspect.Api.General.Models.Response;

namespace StatAspect.Api.General.Extensions;

/// <summary>
/// Provides a set of extension methods for objects that implement <see cref="IApplicationBuilder"/>.
/// </summary>
public static class ApplicationBuilderExtensions
{
    /// <summary>
    /// Adds a middleware to the pipeline that will catch validation exceptions and convert them into a validation error response model.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public static void UseValidationExceptionHandler(this IApplicationBuilder applicationBuilder)
    {
        Guard.Argument(() => applicationBuilder).NotNull();

        applicationBuilder.UseExceptionHandler(ab =>
        {
            ab.Run(async context =>
            {
                var exception = context.Features.Get<IExceptionHandlerFeature>()!.Error;
                if (exception is not ValidationException ex)
                    throw exception;

                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(GetValidationFailureResponseJson(ex), Encoding.UTF8);
            });
        });
    }

    private static string GetValidationFailureResponseJson(ValidationException ex)
    {
        Guard.Argument(() => ex).NotNull();

        return JsonConvert.SerializeObject(new ValidationFailureResponse
        {
            Errors = ex.ToDictionary()
        });
    }
}