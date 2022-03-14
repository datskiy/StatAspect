using StatAspect.Api.General.Extensions;
using StatAspect.Api.General.Helpers;

namespace StatAspect.Api;

public sealed class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        AssemblyHelper.PreloadStartupRequiredAssemblies();

        var apiAssembly = AssemblyHelper.GetApiAssembly();
        var applicationAssembly = AssemblyHelper.GetApplicationAssembly();

        services.AddControllers();
        services.AddAutoMapper(apiAssembly);
        services.AddValidation(applicationAssembly);
        services.AddMediatR(apiAssembly, applicationAssembly);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
            app.UseDeveloperExceptionPage();

        app.UseValidationExceptionHandler();
        app.UseHttpsRedirection();
        app.UseHsts();
        app.UseRouting();
        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
}