﻿using System.Net.Mime;
using StatAspect.Api.General.Models.Response;

namespace StatAspect.Api.General.Extensions;

/// <summary>
/// Provides a set of extension methods for objects that implement <see cref="IApplicationBuilder"/>.
/// </summary>
public static class ApplicationBuilderExtensions
{
    /// <summary>
    /// Adds a middleware to the pipeline for catching validation exceptions and converting them into a unified validation error response model.
    /// </summary>
    /// <exception cref="ArgumentNullException"/>
    public static void UseValidationExceptionHandler(this IApplicationBuilder applicationBuilder)
    {
        Guard.Argument(() => applicationBuilder).NotNull();

        applicationBuilder.UseExceptionHandler(ab =>
        {
            ab.Run(async context =>
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
        return JsonConvert.SerializeObject(new ValidationFailureResponse
        {
            Errors = ex.ToDictionary()
        });
    }
}