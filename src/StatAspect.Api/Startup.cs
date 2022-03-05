using StatAspect.Api.General.Helpers;

namespace StatAspect.Api;

public sealed class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        AssemblyHelper.PreloadRequiredAssemblies();

        services.AddControllers();
        services.AddAutoMapper(AssemblyHelper.GetApiAssembly());
        services.AddMediatR(AssemblyHelper.GetApiAssembly(), AssemblyHelper.GetApplicationAssembly());
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
            app.UseDeveloperExceptionPage();

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
}