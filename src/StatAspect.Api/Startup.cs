using StatAspect.Api.General.Extensions;
using StatAspect.Api.General.Helpers;
using StatAspect.Application.General.Configuration;

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

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>)); // todo: as extension like AddValidationPipeline
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
            app.UseDeveloperExceptionPage();

        app.UseValidationExceptionHandler();
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
}