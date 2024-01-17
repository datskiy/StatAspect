// ReSharper disable ClassNeverInstantiated.Global

namespace StatAspect.Api;

/// <summary>
/// Represents the web app entry point.
/// <remarks>Reflection usage only.</remarks>
/// </summary>
public sealed class Program
{
    /// <summary>
    /// Initializes and runs the web host.
    /// </summary>
    /// <remarks>Reflection usage only.</remarks>
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host
            .CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(hostBuilder => hostBuilder.UseStartup<Startup>());
    }
}