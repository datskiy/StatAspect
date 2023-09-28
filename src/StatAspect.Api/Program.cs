// ReSharper disable ClassNeverInstantiated.Global

namespace StatAspect.Api;

/// <summary>
/// Represents the web app entry point.
/// <remarks>Used only through reflection.</remarks>
/// </summary>
public sealed class Program
{
    /// <summary>
    /// Initializes and runs the web host.
    /// </summary>
    /// <remarks>Used only through reflection.</remarks>
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