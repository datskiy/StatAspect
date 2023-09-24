using StatAspect.Api._Common.Extensions;
using StatAspect.Api._Common.Helpers;

namespace StatAspect.Api;

/// <summary>
/// Represents the application entry point for setting up configuration and wiring up services the application will use.
/// <remarks>Reflection only.</remarks>
/// </summary>
public sealed class Startup
{
    /// <summary>
    /// Configures application services.
    /// <remarks>Reflection only.</remarks>
    /// </summary>
    public void ConfigureServices(IServiceCollection services)
    {
        var apiLayerInitType = StartupHelper.GetApiLayerInitType();
        var applicationLayerInitType = StartupHelper.GetApplicationLayerInitType();

        services.AddControllers();
        services.AddAutoMapper(apiLayerInitType);
        services.AddValidation(applicationLayerInitType);
        services.AddMediatR(apiLayerInitType, applicationLayerInitType);
        services.AddDependencies();
    }

    /// <summary>
    /// Configures application pipeline.
    /// <remarks>Reflection only.</remarks>
    /// </summary>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
            app.UseDeveloperExceptionPage();

        app.UseValidationExceptionHandler();
        app.UseHttpsRedirection();
        app.UseHsts();
        app.UseRouting();
        app.UseEndpoints(erb => erb.MapControllers());
    }
}