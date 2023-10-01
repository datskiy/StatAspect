using StatAspect.Api._Common.Extensions;
using StatAspect.Api._Common.Helpers;

namespace StatAspect.Api;

/// <summary>
/// Represents the web app startup unit.
/// <remarks>Used only through reflection.</remarks>
/// </summary>
public sealed class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// Configures application services.
    /// <remarks>Used only through reflection.</remarks>
    /// </summary>
    public void ConfigureServices(IServiceCollection services)
    {
        var apiAssemblyMarkerType = StartupHelper.GetApiAssemblyMarkerType();
        var applicationAssemblyMarkerType = StartupHelper.GetApplicationAssemblyMarkerType();

        services.AddOptions(_configuration);
        services.AddControllers();
        services.AddAutoMapper(apiAssemblyMarkerType);
        services.AddValidation(applicationAssemblyMarkerType);
        services.AddMediator(apiAssemblyMarkerType, applicationAssemblyMarkerType);
        services.AddDependencies();
    }

    /// <summary>
    /// Configures application pipeline.
    /// <remarks>Used only through reflection.</remarks>
    /// </summary>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
            app.UseDeveloperExceptionPage();

        app.UseValidationExceptionHandler();
        app.UseHttpsRedirection();
        app.UseHsts();
        app.UseRouting();
        app.UseEndpoints(routeBuilder => routeBuilder.MapControllers());
    }
}