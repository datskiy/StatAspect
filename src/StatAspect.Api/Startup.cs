using StatAspect.Application.Queries.MediaTracking;

namespace StatAspect.Api;

public sealed class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        services.AddAutoMapper(typeof(Startup));
        services.AddMediatR(typeof(Startup), typeof(GetSearchKeyQuery)); // todo: better way?
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