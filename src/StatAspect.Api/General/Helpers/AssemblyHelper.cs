namespace StatAspect.Api.General.Helpers;

/// <summary>
/// Provides static methods for accessing assembly information.
/// </summary>
public static class AssemblyHelper
{
    private const string ApiAssemblyName = "StatAspect.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"; // todo: move to config
    private const string ApplicationAssemblyName = "StatAspect.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"; // todo: move to config

    /// <summary>
    /// Preloads assemblies that are required for the startup phase.
    /// </summary>
    public static void PreloadStartupRequiredAssemblies()
    {
        Assembly.Load(ApplicationAssemblyName);
    }

    /// <summary>
    /// Returns the api layer assembly.
    /// </summary>
    public static Assembly GetApiAssembly()
    {
        return GetAssembly(ApiAssemblyName)!;
    }

    /// <summary>
    /// Returns the application layer assembly.
    /// </summary>
    public static Assembly GetApplicationAssembly()
    {
        return GetAssembly(ApplicationAssemblyName)!;
    }

    private static Assembly? GetAssembly(string assemblyName)
    {
        Guard.Argument(() => assemblyName).NotNull();

        return AppDomain.CurrentDomain.GetAssemblies()
            .SingleOrDefault(a => a.FullName!
            .Equals(assemblyName, StringComparison.OrdinalIgnoreCase));
    }
}