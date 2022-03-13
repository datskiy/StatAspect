namespace StatAspect.Api.General.Extensions;

/// <summary>
/// Provides a set of extension methods for objects that implement <see cref="IApplicationBuilder"/>.
/// </summary>
public static class ApplicationBuilderExtensions
{
    /// <summary>
    /// Adds a middleware to the pipeline that will catch validation exceptions and convert them into a validation error response model.
    /// </summary>
    /// <exception cref="ArgumentNullException">description</exception>
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

                context.Response.StatusCode = 400;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(GetErrorResponseJson(context, ex), Encoding.UTF8);
            });
        });
    }

    private static string GetErrorResponseJson(HttpContext context, ValidationException ex) // todo: think about creating a separate model.
    {
        Guard.Argument(() => context).NotNull();
        Guard.Argument(() => ex).NotNull();

        return JsonConvert.SerializeObject(new
        {
            type = $"https://tools.ietf.org/html/rfc7231#section-6.5.1",
            title = "One or more validation errors occurred.",
            status = StatusCodes.Status400BadRequest,
            traceId = Activity.Current?.Id ?? context.TraceIdentifier,
            errors = ex.Errors
                .GroupBy(flr => flr.PropertyName)
                .Select(grp => new
                {
                    PropertyName = grp.Key,
                    ErrorMessages = ex.Errors
                        .Where(flr => flr.PropertyName.Equals(grp.Key, StringComparison.OrdinalIgnoreCase))
                        .Select(flr => flr.ErrorMessage)
                })
                .ToDictionary(k => k.PropertyName, v => v.ErrorMessages.ToArray())
        });
    }
}