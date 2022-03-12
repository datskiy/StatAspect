using StatAspect.Api.General.Helpers;
using StatAspect.Application.General.Configuration;

namespace StatAspect.Api.General.Extensions;

/// <summary>
/// XXX
/// </summary>
public static class ValidationExtensions
{
    /// <summary>
    /// KKK
    /// </summary>
    public static void AddValidation(this IServiceCollection services, Assembly applicationAssembly)
    {
        services.AddFluentValidation(cfg =>
        {
            cfg.RegisterValidatorsFromAssembly(applicationAssembly);
            cfg.ValidatorOptions.LanguageManager = new ValidationLocalizationManager
            {
                Culture = CultureHelper.GetGlobalCulture(),
            };
        });
    }

    /// <summary>
    /// ZZZ
    /// </summary>
    public static void UseValidationExceptionHandler(this IApplicationBuilder applicationBuilder)
    {
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

    private static string GetErrorResponseJson(HttpContext context, ValidationException ex)
    {
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